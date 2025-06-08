using Microsoft.AspNetCore.Http;

namespace UniDto.RegisterDtos
{
    public class CreateRegisterDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordConfirm { get; set; }

        public IFormFile? ProfilePictureUrl { get; set; }
        public string? StudentNumber { get; set; } 
        public IFormFile? VerificationDocumentPath { get; set; }

        public int? UniversityId { get; set; }

        public int? DepartmentId { get; set; }

    }
}
