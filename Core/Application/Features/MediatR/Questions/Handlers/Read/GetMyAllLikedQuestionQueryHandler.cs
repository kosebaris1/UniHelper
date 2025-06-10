using Application.Features.MediatR.Questions.Queries;
using Application.Features.MediatR.Questions.Results;
using Application.Interfaces.QuestionInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Questions.Handlers.Read
{
    public class GetMyAllLikedQuestionQueryHandler : IRequestHandler<GetMyAllLikedQuestionQuery, List<GetMyAllLikedQuestionQueryResult>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetMyAllLikedQuestionQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<List<GetMyAllLikedQuestionQueryResult>> Handle(GetMyAllLikedQuestionQuery request, CancellationToken cancellationToken)
        {
            var myLikedQuestion = await _questionRepository.GetMyAllLikedQuestion(request.UserId);
            return _mapper.Map<List<GetMyAllLikedQuestionQueryResult>>(myLikedQuestion);
        }
    }
}
