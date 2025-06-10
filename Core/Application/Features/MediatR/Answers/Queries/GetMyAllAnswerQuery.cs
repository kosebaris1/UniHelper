using Application.Features.MediatR.Answers.Results;
using MediatR;

namespace Application.Features.MediatR.Answers.Queries
{
    public class GetMyAllAnswerQuery:IRequest<List<GetMyAllAnswerQueryResult>>
    {
        public int UserId { get; set; }

        public GetMyAllAnswerQuery(int userId)
        {
            UserId = userId;
        }
    }
}
