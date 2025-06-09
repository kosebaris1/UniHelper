namespace Application.Features.MediatR.Questions.Results
{
    public class GetByIdQuestionQueryResult
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public string UserProfileUrl { get; set; }
        public string UniversityName { get; set; }
        public string DepartmentName { get; set; }
        public List<string> Tags { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
