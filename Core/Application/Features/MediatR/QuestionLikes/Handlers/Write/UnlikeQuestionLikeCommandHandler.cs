using Application.Features.MediatR.QuestionLikes.Commands;
using Application.Interfaces.QuestionLikeInterface;
using MediatR;

namespace Application.Features.MediatR.QuestionLikes.Handlers.Write
{
    public class UnlikeQuestionLikeCommandHandler : IRequestHandler<UnlikeQuestionLikeCommand, Unit>
    {
        private readonly IQuestionLikeRepository _questionLikeRepository;

        public UnlikeQuestionLikeCommandHandler(IQuestionLikeRepository questionLikeRepository)
        {
            _questionLikeRepository = questionLikeRepository;
        }

        public async Task<Unit> Handle(UnlikeQuestionLikeCommand request, CancellationToken cancellationToken)
        {
            await _questionLikeRepository.UnlikeQuestionAsync(request.UserId, request.QuestionId);
            return Unit.Value;
        }
    }
}
