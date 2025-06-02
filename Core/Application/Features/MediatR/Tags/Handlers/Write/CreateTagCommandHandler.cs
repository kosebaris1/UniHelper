using Application.Features.MediatR.Tags.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.MediatR.Tags.Handlers.Write
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, Unit>
    {
        private readonly IRepository<Tag> _repository;
        private readonly IMapper _mapper;

        public CreateTagCommandHandler(IRepository<Tag> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var tag= _mapper.Map<Tag>(request);
            await _repository.CreateAsync(tag);
            return Unit.Value;
        }
    }
}
