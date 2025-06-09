using Domain.Entities;

namespace Application.Interfaces.AnswerInterface
{
    public interface IAnswerRepository
    {
        Task<List<Answer>> GetAllAnswerByQuestionIdAsync(int questionId);
        Task<Answer> GetAnswerById(int answerId);
        Task<List<Answer>> GetRecentAnswerAsync(int userId,int count);
        Task<List<string>> GetAnswersByQuestionIdForSummaryAsync(int questionId);
    }
}
