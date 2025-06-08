using Application.Features.MediatR.Answers.Queries;
using Application.Features.MediatR.Answers.Results;
using Application.Interfaces.AnswerInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Answers.Handlers.Read
{
    public class GetByIdAnswerQueryHandler : IRequestHandler<GetByIdAnswerQuery, GetByIdAnswerQueryResult>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;
        public GetByIdAnswerQueryHandler(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }
        public async Task<GetByIdAnswerQueryResult> Handle(GetByIdAnswerQuery request, CancellationToken cancellationToken)
        {
            var answer=await _answerRepository.GetAnswerById(request.AnswerId);
            return _mapper.Map<GetByIdAnswerQueryResult>(answer);
        }
    }
}
