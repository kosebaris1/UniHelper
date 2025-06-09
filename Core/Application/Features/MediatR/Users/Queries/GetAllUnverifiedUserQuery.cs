using Application.Features.MediatR.Users.Results;
using MediatR;

namespace Application.Features.MediatR.Users.Queries
{
    public class GetAllUnverifiedUserQuery:IRequest<List<GetAllUnverifiedUserQueryResult>>
    {
    }
}
