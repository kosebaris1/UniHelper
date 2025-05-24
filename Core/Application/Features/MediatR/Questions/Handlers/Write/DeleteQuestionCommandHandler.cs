using Application.Features.MediatR.Questions.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Security.Cryptography;

namespace Application.Features.MediatR.Questions.Handlers.Write
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, Unit>
    {
        private readonly IRepository<Question> _repository;

        public DeleteQuestionCommandHandler(IRepository<Question> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(question);
            return Unit.Value;
        }
    }
}
