using Application.Features.MediatR.Questions.Results;
using MediatR;

namespace Application.Features.MediatR.Questions.Queries
{
    public class GetByIdQuestionQuery:IRequest<GetByIdQuestionQueryResult>
    {
        public int QuestionId { get; set; }

        public GetByIdQuestionQuery(int questionId)
        {
            QuestionId = questionId;
        }
    }
}
