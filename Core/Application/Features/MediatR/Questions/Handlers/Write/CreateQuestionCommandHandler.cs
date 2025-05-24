using Application.Features.MediatR.Questions.Commands;
using Application.Interfaces.QuestionInterface;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.MediatR.Questions.Handlers.Write
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, Unit>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public CreateQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question=_mapper.Map<Question>(request);
            await _questionRepository.CreateQuestionAsync(question, request.TagIds);
            return Unit.Value;
        }
    }
}
