namespace Application.Features.MediatR.Users.Results
{
    public class GetAllUnverifiedUserQueryResult
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? StudentNumber { get; set; }
        public string? VerificationDocumentPath { get; set; }
        public string UniversityName { get; set; }
        public string DepartmentName { get; set; }
    }
}
