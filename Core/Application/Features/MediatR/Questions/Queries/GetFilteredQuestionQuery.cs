using Application.Features.MediatR.Questions.Results;
using MediatR;

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
