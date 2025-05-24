using Application.Interfaces.QuestionLikeInterface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.QuestionLikeRepository
{
    public class QuestionLikeRepository : IQuestionLikeRepository
    {
        private readonly UniHelperContext _context;

        public QuestionLikeRepository(UniHelperContext context)
        {
            _context = context;
        }

        public async Task<bool> IsAlreadyLikedAsync(int userId, int questionId)
        {
            return await _context.QuestionLikes
                .AnyAsync(ql => ql.UserId == userId && ql.QuestionId == questionId);
        }

        public async Task LikeQuestionAsync(int userId, int questionId)
        {
            var alreadyLiked = await IsAlreadyLikedAsync(userId, questionId);

            if (!alreadyLiked)
            {
                var like = new QuestionLike
                {
                    UserId = userId,
                    QuestionId = questionId,
                    LikedDate = DateTime.UtcNow
                };

                _context.QuestionLikes.Add(like);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UnlikeQuestionAsync(int userId, int questionId)
        {
            var like = await _context.QuestionLikes
                .FirstOrDefaultAsync(ql => ql.UserId == userId && ql.QuestionId == questionId);

            if (like != null)
            {
                _context.QuestionLikes.Remove(like);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetLikeCountAsync(int questionId)
        {
            return await _context.QuestionLikes
                .CountAsync(ql => ql.QuestionId == questionId);
        }
    }
}
