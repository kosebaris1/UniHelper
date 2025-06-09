using Application.Features.MediatR.Questions.Queries;
using Application.Features.MediatR.Questions.Results;
using Application.Interfaces.QuestionInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Questions.Handlers.Read
{
    public class GetAllPendingQuestionQueryHandler : IRequestHandler<GetAllPendingQuestionQuery, List<GetAllPendingQuestionQueryResult>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        public GetAllPendingQuestionQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllPendingQuestionQueryResult>> Handle(GetAllPendingQuestionQuery request, CancellationToken cancellationToken)
        {
            var pendingQuestion = await _questionRepository.GetAllPendingQuestionAsync();
            return _mapper.Map<List<GetAllPendingQuestionQueryResult>>(pendingQuestion); 
        }
    }
}
