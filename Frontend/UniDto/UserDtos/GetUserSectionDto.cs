namespace UniDto.UserDtos
{
    public class GetUserSectionDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; } 
        public string? ProfilePictureUrl { get; set; }
        public bool IsVerified { get; set; }
        public string UniversityName { get; set; } 
        public string DepartmentName { get; set; } 
        public int AnswerCount { get; set; }
        public int TotalLikes { get; set; }
    }
}
