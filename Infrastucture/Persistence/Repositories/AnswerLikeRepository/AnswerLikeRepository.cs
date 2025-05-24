using Application.Interfaces.AnswerLikeInterface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.AnswerLikeRepository
{
    public class AnswerLikeRepository : IAnswerLikeRepository
    {
        private readonly UniHelperContext _context;

        public AnswerLikeRepository(UniHelperContext context)
        {
            _context = context;
        }

        public async Task<int> GetLikeCountAsync(int answerId)
        {
           return await _context.AnswerLikes
                .CountAsync(x=> x.AnswerId == answerId);
        }

        public async Task<bool> IsAlreadyLikedAsync(int userId, int answerId)
        {
            return await _context.AnswerLikes
                .AnyAsync(p => p.UserId == userId && p.AnswerId == answerId);
        }

        public async Task LikeAnswerAsync(int userId, int answerId)
        {
            var alreadyLiked=await IsAlreadyLikedAsync(userId, answerId);
            if (!alreadyLiked)
            {
                var like = new AnswerLike
                {
                    UserId= userId,
                    AnswerId= answerId,
                    LikedDate= DateTime.UtcNow
                };
                _context.AnswerLikes.Add(like);
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task UnlikeAnswerAsync(int userId, int answerId)
        {
            var like =await _context.AnswerLikes
                .FirstOrDefaultAsync(x=>x.UserId==userId && x.AnswerId==answerId);
            if (like != null)
            {
                _context.AnswerLikes.Remove(like);
                await _context.SaveChangesAsync();
            }
        }
    }
}
