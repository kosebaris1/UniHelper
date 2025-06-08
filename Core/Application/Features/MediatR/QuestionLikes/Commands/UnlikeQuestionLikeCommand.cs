using MediatR;

namespace Application.Features.MediatR.QuestionLikes.Commands
{
    public class UnlikeQuestionLikeCommand:IRequest<Unit>
    {
        public UnlikeQuestionLikeCommand(int userId, int questionId)
        {
            UserId = userId;
            QuestionId = questionId;
        }

        public int UserId { get; set; }
        public int QuestionId { get; set; }
    }
}
