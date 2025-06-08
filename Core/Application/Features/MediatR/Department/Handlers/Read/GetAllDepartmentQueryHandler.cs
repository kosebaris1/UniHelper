using Application.Features.MediatR.Department.Queries;
using Application.Features.MediatR.Department.Results;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Department.Handlers.Read
{
    public class GetAllDepartmentQueryHandler : IRequestHandler<GetAllDepartmentQuery, List<GetAllDepartmentQueryResult>>
    {
        private readonly IRepository<Domain.Entities.Department> _repository;
        private readonly IMapper _mapper;

        public GetAllDepartmentQueryHandler(IRepository<Domain.Entities.Department> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<List<GetAllDepartmentQueryResult>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync();
            return _mapper.Map<List<GetAllDepartmentQueryResult>>(result);
        }
    }
}
