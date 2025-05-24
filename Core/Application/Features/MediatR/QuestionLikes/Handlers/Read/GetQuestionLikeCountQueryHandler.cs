using Application.Features.MediatR.QuestionLikes.Queries;
using Application.Features.MediatR.QuestionLikes.Results;
using Application.Interfaces;
using Application.Interfaces.QuestionLikeInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.QuestionLikes.Handlers.Read
{
    public class GetQuestionLikeCountQueryHandler : IRequestHandler<GetQuestionLikeCountQuery, GetQuestionLikeCountQueryResult>
    {
        private readonly IQuestionLikeRepository _questionLikeRepository;

        public GetQuestionLikeCountQueryHandler(IQuestionLikeRepository questionLikeRepository)
        {
            _questionLikeRepository = questionLikeRepository;
        }

        public async Task<GetQuestionLikeCountQueryResult> Handle(GetQuestionLikeCountQuery request, CancellationToken cancellationToken)
        {
            int likeCount = await _questionLikeRepository.GetLikeCountAsync(request.QuestionId);
            return new GetQuestionLikeCountQueryResult
            {
                LikeCount= likeCount
            };
        }
    }
}
