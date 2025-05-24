using Application.Features.MediatR.Questions.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Questions.Queries
{
    public class GetFilteredQuestionQuery:IRequest<List<GetFilteredQuestionQueryResult>>
    {
        public GetFilteredQuestionQuery()
        {
        }

        public int? CityId { get; set; }
        public int? UniversityId { get; set; }
        public int? DepartmentId { get; set; }
        public List<int>? TagsId { get; set; }
    }
}
