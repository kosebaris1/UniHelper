using MediatR;

namespace Application.Features.MediatR.Answers.Queries
{
    public class CanUserAnswerQuestionQuery:IRequest<bool>
    {
        public int UserId { get; set; }
        public int QuestionId { get; set; }

        public CanUserAnswerQuestionQuery(int userId, int questionId)
        {
            UserId = userId;
            QuestionId = questionId;
        }
    }
}
