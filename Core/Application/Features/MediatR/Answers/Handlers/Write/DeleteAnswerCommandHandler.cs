using Application.Features.MediatR.Answers.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.MediatR.Answers.Handlers.Write
{
    public class DeleteAnswerCommandHandler : IRequestHandler<DeleteAnswerCommand, Unit>
    {
        private readonly IRepository<Answer> _repository;

        public DeleteAnswerCommandHandler(IRepository<Answer> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer=await _repository.GetByIdAsync(request.AnswerId);
            await _repository.DeleteAsync(answer);
            return Unit.Value;
        }
    }
}
