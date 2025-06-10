namespace Application.Features.MediatR.Users.Results
{
    public class Get3TopLikeUserQueryResult
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string UniversityName { get; set; }
        public string DepartmentName { get; set; }
        public int TotalLikes { get; set; }
    }
}
