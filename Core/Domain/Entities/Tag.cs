using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tag : Entitiy
    {
        public int TagId { get; set; }
        public string Name { get; set; }

        public ICollection<QuestionTag> QuestionTags { get; set; }
    }

}
