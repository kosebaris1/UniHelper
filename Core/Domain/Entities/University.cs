using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class University : Entitiy
    {
        public int UniversityId { get; set; }
        public string Name { get; set; }

        public ICollection<Department> Departments { get; set; }
        public ICollection<User> Users { get; set; }
    }

}
