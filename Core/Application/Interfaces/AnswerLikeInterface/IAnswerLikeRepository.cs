namespace Application.Interfaces.AnswerLikeInterface
{
    public interface IAnswerLikeRepository
    {
        Task<bool> IsAlreadyLikedAsync(int userId, int answerId);
        Task LikeAnswerAsync(int userId, int answerId);
        Task UnlikeAnswerAsync(int userId, int answerId);
        Task<int> GetLikeCountAsync(int answerId);
    }
}
