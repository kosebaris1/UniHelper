using Application.Features.MediatR.Answers.Queries;
using Application.Features.MediatR.Answers.Results;
using Application.Interfaces.AnswerInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Answers.Handlers.Read
{
    public class GetMyAllAnswerQueryHandler : IRequestHandler<GetMyAllAnswerQuery, List<GetMyAllAnswerQueryResult>>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;
        public GetMyAllAnswerQueryHandler(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<List<GetMyAllAnswerQueryResult>> Handle(GetMyAllAnswerQuery request, CancellationToken cancellationToken)
        {
            var myAnswer = await _answerRepository.GetMyAllAnswerAsync(request.UserId);
            return _mapper.Map<List<GetMyAllAnswerQueryResult>>(myAnswer);
        }
    }
}
