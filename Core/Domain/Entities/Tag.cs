namespace Domain.Entities
{
    public class Tag : Entity
    {
        public int TagId { get; set; }
        public string Name { get; set; }

        public ICollection<QuestionTag> QuestionTags { get; set; }
    }

}
