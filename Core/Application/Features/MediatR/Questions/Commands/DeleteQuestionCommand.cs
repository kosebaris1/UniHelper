using MediatR;

namespace Application.Features.MediatR.Questions.Commands
{
    public class DeleteQuestionCommand:IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteQuestionCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
