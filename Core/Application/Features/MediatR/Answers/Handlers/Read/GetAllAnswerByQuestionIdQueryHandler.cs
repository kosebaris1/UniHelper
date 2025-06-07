using Application.Features.MediatR.Answers.Queries;
using Application.Features.MediatR.Answers.Results;
using Application.Interfaces.AnswerInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Answers.Handlers.Read
{
    public class GetAllAnswerByQuestionIdQueryHandler : IRequestHandler<GetAllAnswerByQuestionIdQuery, List<GetAllAnswerByQuestionIdQueryResult>>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;
        public GetAllAnswerByQuestionIdQueryHandler(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllAnswerByQuestionIdQueryResult>> Handle(GetAllAnswerByQuestionIdQuery request, CancellationToken cancellationToken)
        {
            var answers = await _answerRepository.GetAllAnswerByQuestionIdAsync(request.QuestionId);
            var result = _mapper.Map<List<GetAllAnswerByQuestionIdQueryResult>>(answers, opt =>
            {
                opt.Items["CurrentUserId"] = request.CurrentUserId;
            });

            return result;
        }
    }
}
