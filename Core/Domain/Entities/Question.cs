namespace Domain.Entities
{
    public class Question : Entity
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public int? UniversityId { get; set; }
        public University? University { get; set; }
        public string Status { get; set; } = "Pending"; 

        public ICollection<Answer> Answers { get; set; }
        public ICollection<QuestionTag> QuestionTags { get; set; } = new List<QuestionTag>(); // ✅
        public ICollection<QuestionLike> QuestionLikes { get; set; } = new List<QuestionLike>();

        public ICollection<Report> Reports { get; set; }  // Bu cevaba gelen tüm şikayetler


    }

}
