using Application.Features.MediatR.Questions.Commands;
using Application.Interfaces.QuestionInterface;
using MediatR;

namespace Application.Features.MediatR.Questions.Handlers.Write
{
    public class RejectQuestionCommandHandler : IRequestHandler<RejectQuestionCommand, Unit>
    {
        private readonly IQuestionRepository _repository;

        public RejectQuestionCommandHandler(IQuestionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(RejectQuestionCommand request, CancellationToken cancellationToken)
        {
            await _repository.ChangeStatusAsync(request.QuestionId, "Rejected");
            return Unit.Value;
        }
    }
}
