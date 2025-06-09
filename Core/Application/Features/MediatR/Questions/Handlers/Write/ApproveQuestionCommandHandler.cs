using Application.Features.MediatR.Questions.Commands;
using Application.Interfaces.QuestionInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Questions.Handlers.Write
{
    public class ApproveQuestionCommandHandler : IRequestHandler<ApproveQuestionCommand,Unit>
    {
        private readonly IQuestionRepository _repository;

        public ApproveQuestionCommandHandler(IQuestionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(ApproveQuestionCommand request, CancellationToken cancellationToken)
        {
            await _repository.ChangeStatusAsync(request.QuestionId, "Approved");
            return Unit.Value;
        }
    }
}
