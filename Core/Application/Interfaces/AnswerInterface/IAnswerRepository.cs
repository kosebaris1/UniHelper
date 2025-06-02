using Domain.Entities;

namespace Application.Interfaces.AnswerInterface
{
    public interface IAnswerRepository
    {
        Task<List<Answer>> GetAllAnswerByQuestionIdAsync(int questionId);
        Task<Answer> GetAnswerById(int answerId);
    }
}
