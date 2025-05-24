using Application.Features.MediatR.QuestionLikes.Results;
using MediatR;

namespace Application.Features.MediatR.QuestionLikes.Queries
{
    public class IsQuestionLikedByUserQuery:IRequest<IsQuestionLikedByUserQueryResult>
    {
        public IsQuestionLikedByUserQuery(int userId, int questionId)
        {
            UserId = userId;
            QuestionId = questionId;
        }

        public int UserId { get; set; }
        public int QuestionId { get; set; }
    }
}
