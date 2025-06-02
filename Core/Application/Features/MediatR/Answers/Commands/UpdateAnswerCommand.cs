using MediatR;

namespace Application.Features.MediatR.Answers.Commands
{
    public class UpdateAnswerCommand:IRequest<Unit>
    {
        public int AnswerId { get; set; }
        public string Content { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
    }
}
