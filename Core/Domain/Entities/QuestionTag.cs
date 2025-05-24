namespace Domain.Entities
{
    public class QuestionTag : Entity
    {
        public int QuestionTagId { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }

}
