using Application.Features.MediatR.Questions.Results;
using MediatR;

namespace Application.Features.MediatR.Questions.Queries
{
    public class GetMyAllQuestionQuery:IRequest<List<GetMyAllQuestionQueryResult>>
    {
        public int UserId { get; set; }

        public GetMyAllQuestionQuery(int userId)
        {
            UserId = userId;
        }
    }
}
