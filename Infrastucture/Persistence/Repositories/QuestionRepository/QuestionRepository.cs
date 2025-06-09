using Application.Constants;
using Application.Interfaces.QuestionInterface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.QuestionRepository
{
    public class QuestionRepository:IQuestionRepository
    {
        private readonly UniHelperContext _context;

        public QuestionRepository(UniHelperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateQuestionAsync(Question question, List<int> tagIds)
        {
            foreach (var tagId in tagIds)
            {
                question.QuestionTags.Add(new QuestionTag
                {
                    TagId = tagId
                });
            }

            question.CreatedDate= DateTime.Now;
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return question.QuestionId;
        }

        public async Task<List<Question>> GetFilteredQuestions(int? cityId, int? universityId, int? departmentId, List<int>? tagsId, string sortBy)
        {
            var query = _context.Questions
                .Include(p => p.User)
                .Include(q => q.University)
                .Include(q => q.Department)
                .Include(q => q.QuestionTags).ThenInclude(qt => qt.Tag)
                .Include(x => x.QuestionLikes)
                .Include(x => x.Answers)
                .AsQueryable();

            if (universityId.HasValue)
                query = query.Where(q => q.UniversityId == universityId.Value);

            if (departmentId.HasValue)
                query = query.Where(q => q.DepartmentId == departmentId.Value);

            if (cityId.HasValue)
                query = query.Where(q => q.University.CityId == cityId.Value);

            if (tagsId != null && tagsId.Any())
                query = query.Where(q => q.QuestionTags.Any(qt => tagsId.Contains(qt.TagId)));

            // Sıralama
            query = sortBy switch
            {
                "like" => query.OrderByDescending(q => q.QuestionLikes.Count),
                "comment" => query.OrderByDescending(q => q.Answers.Count),
                "new" => query.OrderByDescending(q => q.CreatedDate),
                _ => query.OrderByDescending(q => q.CreatedDate)
            };

            return await query.ToListAsync();
        }


        public async Task<Question> GetQuestionWithDetailsByIdAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question != null && question.DeletedDate == null)
            {
                return await _context.Questions
                 .Include(q => q.User)
                 .Include(q => q.University)
                 .Include(q => q.Department)
                 .Include(q => q.QuestionTags).ThenInclude(qt => qt.Tag)
                 .FirstOrDefaultAsync(q => q.QuestionId == id);
            }
            throw new Exception(Messages<Question>.EntityNotFound);

        }

        public Task<List<Question>> GetTopQuestionAsync(int userId, int count)
        {
            return _context.Questions
                .Where(x => x.DeletedDate == null && x.UserId == userId)
                .Include(x => x.University)
                .Include(x => x.Department)
                .Include(x => x.QuestionTags)
                    .ThenInclude(qt => qt.Tag)
                .Include(x=>x.QuestionLikes)
                .Include(x=>x.Answers)
                .Take(count)
                .OrderByDescending(x=>x.QuestionLikes.Count())
                .ToListAsync();
        }
    }
}
