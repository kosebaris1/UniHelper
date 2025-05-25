using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniDto.RegisterDto
{
    public class CreateRegisterDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? StudentNumber { get; set; } 
        public string? VerificationDocumentPath { get; set; }

        public int? UniversityId { get; set; }

        public int? DepartmentId { get; set; }

    }
}
