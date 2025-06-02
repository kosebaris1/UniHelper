using Application.Features.MediatR.Tags.Results;
using MediatR;

namespace Application.Features.MediatR.Tags.Queries
{
    public class GetAllTagQuery:IRequest<List<GetAllTagQueryResult>>
    {
    }
}
