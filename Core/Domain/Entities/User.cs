using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : Entitiy
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public string StudentNumber { get; set; }
        public bool IsVerified { get; set; }
        public string? VerificationDocumentPath { get; set; }

        public int? UniversityId { get; set; }
        public University? University { get; set; }

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public int? RoleId { get; set; }
        public Role? Role { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }

}
