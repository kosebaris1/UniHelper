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

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return question.QuestionId;
        }

        public async Task<List<Question>> GetFilteredQuestions(int? cityId, int? universityId, int? departmentId, List<int>?  tagsId)
        {
            var query = _context.Questions
                .Include(p=>p.User)
                .Include(q => q.University)
                .Include(q => q.Department)
                .Include(q => q.QuestionTags)
                    .ThenInclude(qt => qt.Tag)
                .AsQueryable();

            if (universityId.HasValue)
                query = query.Where(q => q.UniversityId == universityId.Value);

            if (departmentId.HasValue)
                query = query.Where(q => q.DepartmentId == departmentId.Value);

            if (cityId.HasValue)
                query = query.Where(q => q.University.CityId == cityId.Value);

            if (tagsId != null && tagsId.Any())
                query = query.Where(q => q.QuestionTags.Any(qt => tagsId.Contains(qt.TagId)));

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
    }
}
