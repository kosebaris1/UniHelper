using Application.Features.MediatR.Tags.Queries;
using Application.Features.MediatR.Tags.Results;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.MediatR.Tags.Handlers.Read
{
    public class GetAllTagQueryHandler : IRequestHandler<GetAllTagQuery, List<GetAllTagQueryResult>>
    {
        private readonly IRepository<Tag> _repository;
        private readonly IMapper _mapper;
        public GetAllTagQueryHandler(IRepository<Tag> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAllTagQueryResult>> Handle(GetAllTagQuery request, CancellationToken cancellationToken)
        {
            var tags = await _repository.GetAllAsync();
            return _mapper.Map<List<GetAllTagQueryResult>>(tags);
        }
    }
}
