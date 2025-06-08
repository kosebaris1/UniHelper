using Application.Features.MediatR.Department.Results;
using MediatR;

namespace Application.Features.MediatR.Department.Queries
{
    public class GetAllDistinctDepartmentQuery:IRequest<List<GetAllDistinctDepartmentQueryResult>>
    {
    }
}
