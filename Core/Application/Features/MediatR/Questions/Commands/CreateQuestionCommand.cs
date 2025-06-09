using MediatR;

namespace Application.Features.MediatR.Questions.Commands
{
    public class CreateQuestionCommand:IRequest<Unit>
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int? DepartmentId { get; set; }
        public int? UniversityId { get; set; }
        public List<int> TagIds { get; set; } 
    }
}
