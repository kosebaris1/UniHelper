using Application.Features.MediatR.QuestionLikes.Queries;
using Application.Features.MediatR.QuestionLikes.Results;
using Application.Interfaces.QuestionLikeInterface;
using MediatR;

namespace Application.Features.MediatR.QuestionLikes.Handlers.Read
{
    public class IsQuestionLikedByUserQueryHandler : IRequestHandler<IsQuestionLikedByUserQuery, IsQuestionLikedByUserQueryResult>
    {
        private readonly IQuestionLikeRepository _questionLikeRepository;

        public IsQuestionLikedByUserQueryHandler(IQuestionLikeRepository questionLikeRepository)
        {
            _questionLikeRepository = questionLikeRepository;
        }
        public async Task<IsQuestionLikedByUserQueryResult> Handle(IsQuestionLikedByUserQuery request, CancellationToken cancellationToken)
        {
            
            bool value= await _questionLikeRepository.IsAlreadyLikedAsync(request.UserId, request.QuestionId);
            return new IsQuestionLikedByUserQueryResult
            {
                LikedByUser = value
            };
        }
    }
}
