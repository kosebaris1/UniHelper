namespace Application.Interfaces.GptSummaryInterface
{
    public interface IGeminiSummaryService
    {
        Task<string> GetSummaryAsync(List<string> answers);

    }
}
