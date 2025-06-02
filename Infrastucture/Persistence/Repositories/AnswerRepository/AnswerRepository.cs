using Application.Interfaces.AnswerInterface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.AnswerRepository
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly UniHelperContext _context;

        public AnswerRepository(UniHelperContext context)
        {
            _context = context;
        }

        public async Task<List<Answer>> GetAllAnswerByQuestionIdAsync(int questionId)
        {
            return await _context.Answers
                .Where(x => x.DeletedDate == null && x.QuestionId == questionId)
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<Answer> GetAnswerById(int answerId)
        {
            return await _context.Answers
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.DeletedDate == null && x.AnswerId == answerId);
        }
    }
}
