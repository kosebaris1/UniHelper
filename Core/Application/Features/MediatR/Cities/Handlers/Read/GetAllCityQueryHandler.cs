using Application.Features.MediatR.Cities.Queries;
using Application.Features.MediatR.Cities.Results;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.MediatR.Cities.Handlers.Read
{
    public class GetAllCityQueryHandler : IRequestHandler<GetAllCityQuery, List<GetAllCityQueryResult>>
    {
        private readonly IRepository<City> _repository;
        private readonly IMapper _mapper;
        public GetAllCityQueryHandler(IRepository<City> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAllCityQueryResult>> Handle(GetAllCityQuery request, CancellationToken cancellationToken)
        {
            var cities = await _repository.GetAllAsync();
            return _mapper.Map<List<GetAllCityQueryResult>>(cities);
        }
    }
}
