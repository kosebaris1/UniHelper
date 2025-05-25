using Application.Features.MediatR.Department.Queries;
using Application.Features.MediatR.Department.Results;
using Application.Features.MediatR.Users.Results;
using Application.Interfaces.DepartmentInterface;
using Application.Interfaces.UserInterface;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Department.Handlers.Read
{
    public class GetDepartmentsByUniversityQueryHandler : IRequestHandler<GetDepartmentsByUniversityQuery, List<GetDepartmentsByUniversityQueryResult>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public GetDepartmentsByUniversityQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<List<GetDepartmentsByUniversityQueryResult>> Handle(GetDepartmentsByUniversityQuery request, CancellationToken cancellationToken)
        {
            var result = await _departmentRepository.GetDepartmentsByUniversity(request.Id);

            return _mapper.Map<List<GetDepartmentsByUniversityQueryResult>>(result);
        }
    }
}
