namespace UniDto.UserDtos
{
    public class GetBest3UserDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string UniversityName { get; set; }
        public string DepartmentName { get; set; }
        public int TotalLikes { get; set; }
    }
}
