using MediatR;

namespace Application.Features.MediatR.AnswerLikes.Commands
{
    public class UnlikeAnswerLikeCommand:IRequest<Unit>
    {
        public int UserId { get; set; }
        public int AnswerId { get; set; }
    }
}
