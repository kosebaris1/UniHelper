using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.MediatR.Users.Commands
{
    public class CreateUserCommand : IRequest<Unit>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public IFormFile? ProfilePictureUrl { get; set; }
        public string? StudentNumber { get; set; }
        public IFormFile? VerificationDocumentPath { get; set; }

        public int? UniversityId { get; set; }  

        public int? DepartmentId { get; set; }

    }
}
