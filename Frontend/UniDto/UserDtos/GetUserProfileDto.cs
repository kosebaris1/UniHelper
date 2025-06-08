namespace UniDto.UserDtos
{
    public class GetUserProfileDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; } //
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string StudentNumber { get; set; }
        public bool IsVerified { get; set; }
        public string UniversityName { get; set; } //

        public string DepartmentName { get; set; } // 

        public string RoleName { get; set; }

        public int AnswerCount { get; set; }
        public int TotalLikes { get; set; }
    }
}
