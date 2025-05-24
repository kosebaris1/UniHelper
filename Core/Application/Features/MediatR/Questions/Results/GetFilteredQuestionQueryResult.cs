using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Questions.Results
{
    public class GetFilteredQuestionQueryResult
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string DepartmentName { get; set; }
        public string UniversityName { get; set; }
        public List<string> QuestionTags { get; set; }

    }
}
