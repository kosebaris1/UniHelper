using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Question : Entitiy
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public ICollection<QuestionTag> QuestionTags { get; set; }
    }

}
