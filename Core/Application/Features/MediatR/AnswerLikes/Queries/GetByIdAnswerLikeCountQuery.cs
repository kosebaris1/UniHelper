using Application.Features.MediatR.AnswerLikes.Results;
using MediatR;

namespace Application.Features.MediatR.AnswerLikes.Queries
{
    public class GetByIdAnswerLikeCountQuery:IRequest<GetByIdAnswerLikeCountQueryResult>
    {
        public int AsnwerId { get; set; }

        public GetByIdAnswerLikeCountQuery(int asnwerId)
        {
            AsnwerId = asnwerId;
        }
    }
}
