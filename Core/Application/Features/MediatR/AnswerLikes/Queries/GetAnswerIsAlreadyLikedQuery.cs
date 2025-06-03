using Application.Features.MediatR.AnswerLikes.Results;
using MediatR;

namespace Application.Features.MediatR.AnswerLikes.Queries
{
    public class GetAnswerIsAlreadyLikedQuery:IRequest<GetAnswerIsAlreadyLikedQueryResult>
    {
        public GetAnswerIsAlreadyLikedQuery(int userId, int answerId)
        {
            UserId = userId;
            AnswerId = answerId;
        }

        public int UserId { get; set; }
        public int AnswerId { get; set;}
    }
}
