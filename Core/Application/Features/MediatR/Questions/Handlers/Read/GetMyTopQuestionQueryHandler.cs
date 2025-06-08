using Application.Features.MediatR.Questions.Queries;
using Application.Features.MediatR.Questions.Results;
using Application.Interfaces.QuestionInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Questions.Handlers.Read
{
    public class GetMyTopQuestionQueryHandler : IRequestHandler<GetMyTopQuestionQuery, List<GetMyTopQuestionQueryResult>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        public GetMyTopQuestionQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<List<GetMyTopQuestionQueryResult>> Handle(GetMyTopQuestionQuery request, CancellationToken cancellationToken)
        {
            var questions = await _questionRepository.GetTopQuestionAsync(request.UserId, request.Count);
            return _mapper.Map<List<GetMyTopQuestionQueryResult>>(questions);
        }
    }
}
