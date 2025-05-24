using Application.Features.MediatR.AnswerLikes.Commands;
using Application.Interfaces.AnswerLikeInterface;
using MediatR;

namespace Application.Features.MediatR.AnswerLikes.Handlers.Write
{
    public class UnlikeAnswerLikeCommandHandler : IRequestHandler<UnlikeAnswerLikeCommand, Unit>
    {
        private readonly IAnswerLikeRepository _answerLikeRepository;

        public UnlikeAnswerLikeCommandHandler(IAnswerLikeRepository answerLikeRepository)
        {
            _answerLikeRepository = answerLikeRepository;
        }

        public async Task<Unit> Handle(UnlikeAnswerLikeCommand request, CancellationToken cancellationToken)
        {
            await _answerLikeRepository.UnlikeAnswerAsync(request.UserId, request.AnswerId);
            return Unit.Value;
        }
    }
}
