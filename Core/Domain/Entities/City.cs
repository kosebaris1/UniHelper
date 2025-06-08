using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class City:Entity
    {
        public int CityId { get; set; }
        public string Name { get; set; }

        public ICollection<University> Universities { get; set; }
    }
}
