using Application.Features.MediatR.Users.Results;
using MediatR;

namespace Application.Features.MediatR.Users.Queries
{
    public class Get3TopLikeUserQuery:IRequest<List<Get3TopLikeUserQueryResult>>
    {
    }
}
