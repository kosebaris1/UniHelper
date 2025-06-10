using Application.Features.MediatR.Questions.Queries;
using Application.Features.MediatR.Questions.Results;
using Application.Interfaces.QuestionInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Questions.Handlers.Read
{
    public class GetMyAllQuestionQueryHandler : IRequestHandler<GetMyAllQuestionQuery, List<GetMyAllQuestionQueryResult>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetMyAllQuestionQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }
        public async Task<List<GetMyAllQuestionQueryResult>> Handle(GetMyAllQuestionQuery request, CancellationToken cancellationToken)
        {
            var myQuestions = await _questionRepository.GetMyAllQuestion(request.UserId);
            return _mapper.Map<List<GetMyAllQuestionQueryResult>>(myQuestions);
        }
    }
}
