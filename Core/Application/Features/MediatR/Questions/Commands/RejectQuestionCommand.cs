using MediatR;

namespace Application.Features.MediatR.Questions.Commands
{
    public class RejectQuestionCommand:IRequest<Unit>
    {
        public int QuestionId { get; set; }
    }
}
