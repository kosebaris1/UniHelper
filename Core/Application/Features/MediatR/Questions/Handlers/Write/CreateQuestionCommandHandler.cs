using Application.Features.MediatR.Questions.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Questions.Handlers.Write
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, Unit>
    {
        private readonly IRepository<Question> _repository;
        private readonly IMapper _mapper;

        public CreateQuestionCommandHandler(IRepository<Question> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question=_mapper.Map<Question>(request);
            await _repository.CreateAsync(question);
            return Unit.Value;
        }
    }
}
