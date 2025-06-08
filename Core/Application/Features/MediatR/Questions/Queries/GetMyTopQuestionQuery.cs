using Application.Features.MediatR.Questions.Results;
using MediatR;

namespace Application.Features.MediatR.Questions.Queries
{
    public class GetMyTopQuestionQuery:IRequest<List<GetMyTopQuestionQueryResult>>
    {
        public int UserId { get; set; }
        public int Count { get; set; }

        public GetMyTopQuestionQuery(int userId, int count)
        {
            UserId = userId;
            Count = count;
        }
    }
}
