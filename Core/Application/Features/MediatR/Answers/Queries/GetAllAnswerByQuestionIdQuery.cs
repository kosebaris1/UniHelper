using Application.Features.MediatR.Answers.Results;
using MediatR;

namespace Application.Features.MediatR.Answers.Queries
{
    public class GetAllAnswerByQuestionIdQuery:IRequest<List<GetAllAnswerByQuestionIdQueryResult>>
    {
        public int QuestionId { get; set; }
        public int CurrentUserId { get; set; }


        public GetAllAnswerByQuestionIdQuery(int questionId, int currentUserId)
        {
            QuestionId = questionId;
            CurrentUserId = currentUserId;
        }
    }
}
