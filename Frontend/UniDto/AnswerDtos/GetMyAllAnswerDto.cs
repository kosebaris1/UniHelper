namespace UniDto.AnswerDtos
{
    public class GetMyAllAnswerDto
    {
        public int AnswerId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public int UserId { get; set; }
    }
}
