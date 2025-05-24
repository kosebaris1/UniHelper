namespace Domain.Entities
{
    public class AnswerLike
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
        public DateTime LikedDate { get; set; } = DateTime.UtcNow;
    }
}
