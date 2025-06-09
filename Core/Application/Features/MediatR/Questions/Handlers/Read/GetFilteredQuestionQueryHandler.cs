using Application.Features.MediatR.Questions.Queries;
using Application.Features.MediatR.Questions.Results;
using Application.Interfaces.QuestionInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Questions.Handlers.Read
{
    public class GetFilteredQuestionQueryHandler : IRequestHandler<GetFilteredQuestionQuery, List<GetFilteredQuestionQueryResult>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        public GetFilteredQuestionQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<List<GetFilteredQuestionQueryResult>> Handle(GetFilteredQuestionQuery request, CancellationToken cancellationToken)
        {
            var filteredQuestion = await _questionRepository.GetFilteredQuestions(request.CityId,request.UniversityId,request.DepartmentId,request.TagsId,request.SortBy);
            return _mapper.Map<List<GetFilteredQuestionQueryResult>>(filteredQuestion);
        }
    }
}
