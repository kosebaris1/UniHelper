using Application.Features.MediatR.AnswerLikes.Commands;
using Application.Interfaces.AnswerLikeInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.AnswerLikes.Handlers.Write
{
    public class CreateAnswerLikeCommandHandler : IRequestHandler<CreateAnswerLikeCommand, Unit>
    {
        private readonly IAnswerLikeRepository _answerLikeRepository;

        public CreateAnswerLikeCommandHandler(IAnswerLikeRepository answerLikeRepository)
        {
            _answerLikeRepository = answerLikeRepository;
        }

        public async Task<Unit> Handle(CreateAnswerLikeCommand request, CancellationToken cancellationToken)
        {
            await _answerLikeRepository.LikeAnswerAsync(request.UserId, request.AnswerId);
            return Unit.Value;
        }
    }
}
