namespace Application.Features.MediatR.Users.Results
{
    public class GetRecentVerifiedUserQueryResult
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string UniversityName { get; set; }
        public string DepartmentName { get; set; }
    }
}
