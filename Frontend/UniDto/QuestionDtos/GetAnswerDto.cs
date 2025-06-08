namespace UniDto.QuestionDtos
{
    public class GetAnswerDto
    {
        public int AnswerId { get; set; }
        public string Content { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public int LikeCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsLikedByCurrentUser { get; set; }
        public bool IsVerified { get; set; }
        public string? UniversityName { get; set; }
        public string? DepartmentName { get; set; }
        public string? ProfilePictureUrl { get; set; }

    }
}
