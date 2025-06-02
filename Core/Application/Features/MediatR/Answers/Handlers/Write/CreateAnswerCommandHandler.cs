using Application.Features.MediatR.Answers.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.MediatR.Answers.Handlers.Write
{
    public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswersCommand, Unit>
    {
        private readonly IRepository<Answer> _repository;
        private readonly IMapper _mapper;
        public CreateAnswerCommandHandler(IRepository<Answer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateAnswersCommand request, CancellationToken cancellationToken)
        {
            var answer = _mapper.Map<Answer>(request);
            await _repository.CreateAsync(answer);
            return Unit.Value;
        }
    }
}
