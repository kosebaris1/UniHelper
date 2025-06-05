using Application.Features.MediatR.Questions.Queries;
using Application.Features.MediatR.Questions.Results;
using Application.Interfaces.QuestionInterface;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Questions.Handlers.Read
{
    public class GetByIdQuestionQueryHandler : IRequestHandler<GetByIdQuestionQuery, GetByIdQuestionQueryResult>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetByIdQuestionQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }
        public async Task<GetByIdQuestionQueryResult> Handle(GetByIdQuestionQuery request, CancellationToken cancellationToken)
        {
            var question = await _questionRepository.GetQuestionWithDetailsByIdAsync(request.QuestionId);
            if (question == null) return null;

            return _mapper.Map<GetByIdQuestionQueryResult>(question);
        }
    }
}
