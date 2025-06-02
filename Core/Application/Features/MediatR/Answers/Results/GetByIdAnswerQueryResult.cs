namespace Application.Features.MediatR.Answers.Results
{
    public class GetByIdAnswerQueryResult
    {
        public int AnswerId { get; set; }
        public string Content { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
    }
}
