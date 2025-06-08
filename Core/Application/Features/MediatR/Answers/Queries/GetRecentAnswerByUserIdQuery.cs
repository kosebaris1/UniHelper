using Application.Features.MediatR.Answers.Results;
using MediatR;

namespace Application.Features.MediatR.Answers.Queries
{
    public class GetRecentAnswerByUserIdQuery:IRequest<List<GetRecentAnswerByUserIdQueryResult>>
    {
        public int UserId { get; set; }
        public int Count { get; set; }

        public GetRecentAnswerByUserIdQuery(int userId, int count)
        {
            UserId = userId;
            Count = count;
        }
    }
}
