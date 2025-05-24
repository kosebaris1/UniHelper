using Application.Features.MediatR.Universities.Queries;
using Application.Features.MediatR.Universities.Results;
using Application.Features.MediatR.Users.Queries;
using Application.Features.MediatR.Users.Results;
using Application.Interfaces.UniversitiesInterface;
using Application.Interfaces.UserInterface;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Universities.Handlers.Read
{

    public class GetAllUniversityQueryHandler : IRequestHandler<GetAllUniversityQuery, List<GetAllUniversityQueryResult>>
    {
        private readonly IUniversitiesRepository _universitiesRepository;
        private readonly IMapper _mapper;

        public GetAllUniversityQueryHandler(IMapper mapper, IUniversitiesRepository universitiesRepository)
        {
            _mapper = mapper;
            _universitiesRepository = universitiesRepository;
        }

        public async Task<List<GetAllUniversityQueryResult>> Handle(GetAllUniversityQuery request, CancellationToken cancellationToken)
        {
            var users = await _universitiesRepository.GetAllUniversityAsync();
            return _mapper.Map<List<GetAllUniversityQueryResult>>(users);
        }
    }
}
