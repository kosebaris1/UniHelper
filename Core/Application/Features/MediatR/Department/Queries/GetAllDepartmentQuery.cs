using Application.Features.MediatR.Department.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Department.Queries
{
    public class GetAllDepartmentQuery : IRequest<List<GetAllDepartmentQueryResult>>
    {
    }
}
