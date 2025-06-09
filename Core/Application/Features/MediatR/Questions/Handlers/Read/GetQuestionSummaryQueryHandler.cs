using Application.Features.MediatR.Questions.Queries;
using Application.Interfaces.AnswerInterface;
using Application.Interfaces.GptSummaryInterface;
using MediatR;

namespace Application.Features.MediatR.Questions.Handlers.Read
{
    public class GetQuestionSummaryQueryHandler : IRequestHandler<GetQuestionSummaryQuery, string>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IGeminiSummaryService _gptService;

        public GetQuestionSummaryQueryHandler(IAnswerRepository answerRepository, IGeminiSummaryService gptService)
        {
            _answerRepository = answerRepository;
            _gptService = gptService;
        }   

        public async Task<string> Handle(GetQuestionSummaryQuery request, CancellationToken cancellationToken)
        {
            var answers = await _answerRepository.GetAnswersByQuestionIdForSummaryAsync(request.QuestionId);

            if (answers == null || !answers.Any())
                return "Bu soru için henüz özetlenecek bir cevap bulunmamaktadır.";

            var summary = await _gptService.GetSummaryAsync(answers);
            return summary;
        }
    }
}
