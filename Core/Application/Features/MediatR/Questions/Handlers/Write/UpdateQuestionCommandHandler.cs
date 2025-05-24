using Application.Features.MediatR.Questions.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.MediatR.Questions.Handlers.Write
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, Unit>
    {
        private readonly IRepository<Question> _repository;
        private readonly IMapper _mapper;
        public UpdateQuestionCommandHandler(IRepository<Question> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question=await _repository.GetByIdAsync(request.QuestionId);
            _mapper.Map(request, question);
            await _repository.UpdateAsync(question);
            return Unit.Value;
        }
    }
}
