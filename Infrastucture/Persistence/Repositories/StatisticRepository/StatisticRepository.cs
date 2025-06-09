using Application.Features.MediatR.Statistics.Results;
using Application.Interfaces.StatisticInterface;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.StatisticRepository
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly UniHelperContext _context;

        public StatisticRepository(UniHelperContext uniHelperContext)
        {
            _context = uniHelperContext;
        }

        public async Task<AdminDashboardQueryResult> GetDashboardDataAsync()
        {
            var totalUsers = await _context.Users.CountAsync();

            var verifiedUsers = await _context.Users.CountAsync(u => u.IsVerified == true);
            var pendingUserApprovals = await _context.Users.CountAsync(u => u.IsVerified != true);

            // ✅ Status'e göre filtrelenmiş soru sayıları
            var publishedQuestions = await _context.Questions.CountAsync(q => q.Status == "Approved");
            var pendingQuestions = await _context.Questions.CountAsync(q => q.Status == "Pending");

            var totalAnswers = await _context.Answers.CountAsync();

            var mostLikedAnswerUser = await _context.AnswerLikes
                .GroupBy(like => new { like.Answer.UserId, like.Answer.User.FullName })
                .Select(group => new
                {
                    group.Key.FullName,
                    TotalLikes = group.Count()
                })
                .OrderByDescending(g => g.TotalLikes)
                .FirstOrDefaultAsync();

            var mostLikedQuestionUser = await _context.QuestionLikes
                .GroupBy(like => new { like.Question.UserId, like.Question.User.FullName })
                .Select(group => new
                {
                    group.Key.FullName,
                    TotalLikes = group.Count()
                })
                .OrderByDescending(g => g.TotalLikes)
                .FirstOrDefaultAsync();

            return new AdminDashboardQueryResult
            {
                TotalUsers = totalUsers,
                VerifiedUsers = verifiedUsers,
                PendingUserApprovals = pendingUserApprovals,
                PublishedQuestions = publishedQuestions,
                PendingQuestions = pendingQuestions,
                TotalAnswers = totalAnswers,
                MostLikedAnswerUser = mostLikedAnswerUser?.FullName ?? "Yok",
                MostLikedAnswerUserTotalLikes = mostLikedAnswerUser?.TotalLikes ?? 0,
                MostLikedQuestionUser = mostLikedQuestionUser?.FullName ?? "Yok",
                MostLikedQuestionUserTotalLikes = mostLikedQuestionUser?.TotalLikes ?? 0,
            };
        }
    }
}
