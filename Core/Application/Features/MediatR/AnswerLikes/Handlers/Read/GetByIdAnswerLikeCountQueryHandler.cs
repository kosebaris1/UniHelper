using Application.Features.MediatR.AnswerLikes.Queries;
using Application.Features.MediatR.AnswerLikes.Results;
using Application.Interfaces.AnswerLikeInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.AnswerLikes.Handlers.Read
{
    public class GetByIdAnswerLikeCountQueryHandler : IRequestHandler<GetByIdAnswerLikeCountQuery, GetByIdAnswerLikeCountQueryResult>
    {
        private readonly IAnswerLikeRepository _answerLikeRepository;
        private readonly IMapper _mapper;
        public GetByIdAnswerLikeCountQueryHandler(IAnswerLikeRepository answerLikeRepository, IMapper mapper)
        {
            _answerLikeRepository = answerLikeRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdAnswerLikeCountQueryResult> Handle(GetByIdAnswerLikeCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _answerLikeRepository.GetLikeCountAsync(request.AsnwerId);
            return new GetByIdAnswerLikeCountQueryResult
            {
                LikeCount= value
            };
        }
    }
}
