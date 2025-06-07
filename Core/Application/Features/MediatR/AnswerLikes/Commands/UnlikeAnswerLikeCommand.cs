using MediatR;

namespace Application.Features.MediatR.AnswerLikes.Commands
{
    public class UnlikeAnswerLikeCommand:IRequest<Unit>
    {
        public UnlikeAnswerLikeCommand(int userId, int answerId)
        {
            UserId = userId;
            AnswerId = answerId;
        }

        public int UserId { get; set; }
        public int AnswerId { get; set; }
    }
}
