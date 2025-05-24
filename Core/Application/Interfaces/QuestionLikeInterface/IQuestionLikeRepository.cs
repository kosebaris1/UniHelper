using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.QuestionLikeInterface
{
    public interface IQuestionLikeRepository
    {
        Task<bool> IsAlreadyLikedAsync(int userId, int questionId);
        Task LikeQuestionAsync(int userId, int questionId);
        Task UnlikeQuestionAsync(int userId, int questionId);
        Task<int> GetLikeCountAsync(int questionId);
    }
}
