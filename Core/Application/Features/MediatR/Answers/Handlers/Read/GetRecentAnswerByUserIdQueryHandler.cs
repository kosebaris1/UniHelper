using Application.Features.MediatR.Answers.Queries;
using Application.Features.MediatR.Answers.Results;
using Application.Interfaces.AnswerInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Answers.Handlers.Read
{
    public class GetRecentAnswerByUserIdQueryHandler : IRequestHandler<GetRecentAnswerByUserIdQuery, List<GetRecentAnswerByUserIdQueryResult>>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;
        public GetRecentAnswerByUserIdQueryHandler(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<List<GetRecentAnswerByUserIdQueryResult>> Handle(GetRecentAnswerByUserIdQuery request, CancellationToken cancellationToken)
        {
            var answers = await _answerRepository.GetRecentAnswerAsync(request.UserId,request.Count);
            return _mapper.Map<List<GetRecentAnswerByUserIdQueryResult>>(answers);
        }
    }
}
