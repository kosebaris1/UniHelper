using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniDto.UserDtos
{
    public class GetRecentUserDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string UniversityName { get; set; }
        public string DepartmentName { get; set; }
    }
}
