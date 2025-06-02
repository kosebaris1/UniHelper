using Application.Features.MediatR.Answers.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.MediatR.Answers.Handlers.Write
{
    public class UpdateAnswerCommandHandler : IRequestHandler<UpdateAnswerCommand, Unit>
    {
        private readonly IRepository<Answer> _repository;
        private readonly IMapper _mapper;
        public UpdateAnswerCommandHandler(IRepository<Answer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = await _repository.GetByIdAsync(request.AnswerId);
            _mapper.Map(request, answer);
            await _repository.UpdateAsync(answer);
            return Unit.Value;
        }
    }
}
