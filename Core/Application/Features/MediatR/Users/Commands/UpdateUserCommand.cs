using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Users.Commands
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public IFormFile? ProfilePictureUrl { get; set; }
        public string StudentNumber { get; set; }
        public IFormFile? VerificationDocumentPath { get; set; }

        public int? UniversityId { get; set; }

        public int? DepartmentId { get; set; }
    }
}
