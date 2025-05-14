using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Users.Results
{
    public class GetAllUserQueryResult
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public string StudentNumber { get; set; }
        public bool IsVerified { get; set; }
        public string? VerificationDocumentPath { get; set; }

        public int? UniversityId { get; set; }

        public int? DepartmentId { get; set; }

        public int? RoleId { get; set; }

    }
}
