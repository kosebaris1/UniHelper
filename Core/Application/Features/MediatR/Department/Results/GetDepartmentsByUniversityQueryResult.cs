using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Department.Results
{
    public class GetDepartmentsByUniversityQueryResult
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int UniversityId { get; set; }
    }
}
