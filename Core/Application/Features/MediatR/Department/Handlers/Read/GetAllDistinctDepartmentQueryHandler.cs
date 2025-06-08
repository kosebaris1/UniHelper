using Application.Features.MediatR.Department.Queries;
using Application.Features.MediatR.Department.Results;
using Application.Interfaces.DepartmentInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Department.Handlers.Read
{
    public class GetAllDistinctDepartmentQueryHandler : IRequestHandler<GetAllDistinctDepartmentQuery, List<GetAllDistinctDepartmentQueryResult>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public GetAllDistinctDepartmentQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllDistinctDepartmentQueryResult>> Handle(GetAllDistinctDepartmentQuery request, CancellationToken cancellationToken)
        {
            var departments = await _departmentRepository.GetAllDistinctDepartmentsAsync();
            return _mapper.Map<List<GetAllDistinctDepartmentQueryResult>>(departments);
        }
    }
}
