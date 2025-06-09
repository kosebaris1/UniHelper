namespace UniDto.QuestionDtos
{
    public class GetLastQuestionDto
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
    }
}
