using Application.Features.MediatR.Answers.Results;
using MediatR;

namespace Application.Features.MediatR.Answers.Queries
{
    public class GetByIdAnswerQuery:IRequest<GetByIdAnswerQueryResult>
    {
        public int AnswerId { get; set; }

        public GetByIdAnswerQuery(int answerId)
        {
            AnswerId = answerId;
        }
    }
}
