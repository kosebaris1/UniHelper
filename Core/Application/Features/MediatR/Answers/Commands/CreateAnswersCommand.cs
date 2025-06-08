using Domain.Entities;
using MediatR;

namespace Application.Features.MediatR.Answers.Commands
{
    public class CreateAnswersCommand:IRequest<Unit>
    {
        public string Content { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }

    }
}
