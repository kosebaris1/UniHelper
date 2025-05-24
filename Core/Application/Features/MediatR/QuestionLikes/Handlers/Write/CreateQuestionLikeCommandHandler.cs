using Application.Features.MediatR.QuestionLikes.Commands;
using Application.Interfaces.QuestionLikeInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.QuestionLikes.Handlers.Write
{
    public class CreateQuestionLikeCommandHandler : IRequestHandler<CreateQuestionLikeCommand, Unit>
    {
        private readonly IQuestionLikeRepository _questionLikeRepository;

        public CreateQuestionLikeCommandHandler(IQuestionLikeRepository questionLikeRepository)
        {
            _questionLikeRepository = questionLikeRepository;
        }

        public async Task<Unit> Handle(CreateQuestionLikeCommand request, CancellationToken cancellationToken)
        {
            await _questionLikeRepository.LikeQuestionAsync(request.UserId, request.QuestionId);
            return Unit.Value;
        }
    }
}
