using MediatR;

namespace Application.Features.MediatR.Questions.Commands
{
    public class UpdateQuestionCommand:IRequest<Unit>
    {
        public int QuestionId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}
