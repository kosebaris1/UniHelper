using MediatR;

namespace Application.Features.MediatR.Questions.Commands
{
    public class ApproveQuestionCommand:IRequest<Unit>
    {
        public int QuestionId { get; set; }

    }
}
