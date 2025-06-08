using Application.Features.MediatR.AnswerLikes.Queries;
using Application.Features.MediatR.AnswerLikes.Results;
using Application.Interfaces.AnswerLikeInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.AnswerLikes.Handlers.Read
{
    public class GetAnswerIsAlreadyLikedQueryHandler : IRequestHandler<GetAnswerIsAlreadyLikedQuery, GetAnswerIsAlreadyLikedQueryResult>
    {
        private readonly IAnswerLikeRepository _answerLikeRepository;
        private readonly IMapper _mapper;
        public GetAnswerIsAlreadyLikedQueryHandler(IAnswerLikeRepository answerLikeRepository, IMapper mapper)
        {
            _answerLikeRepository = answerLikeRepository;
            _mapper = mapper;
        }
        public async Task<GetAnswerIsAlreadyLikedQueryResult> Handle(GetAnswerIsAlreadyLikedQuery request, CancellationToken cancellationToken)
        {
            var isLiked=await _answerLikeRepository.IsAlreadyLikedAsync(request.UserId,request.AnswerId);
            return new GetAnswerIsAlreadyLikedQueryResult
            {
                IsAlreadyLiked=isLiked
            };
        }
    }
}
