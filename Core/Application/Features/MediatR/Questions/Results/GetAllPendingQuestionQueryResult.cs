namespace Application.Features.MediatR.Questions.Results
{
    public class GetAllPendingQuestionQueryResult
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }

    }
}
