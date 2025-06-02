using Application.Features.MediatR.Answers.Results;
using MediatR;

namespace Application.Features.MediatR.Answers.Queries
{
    public class GetAllAnswerByQuestionIdQuery:IRequest<List<GetAllAnswerByQuestionIdQueryResult>>
    {
        public int QuestionId { get; set; }

        public GetAllAnswerByQuestionIdQuery(int questionId)
        {
            QuestionId = questionId;
        }
    }
}
