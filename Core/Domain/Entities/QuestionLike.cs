namespace Domain.Entities
{
    public class QuestionLike
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public DateTime LikedDate { get; set; } = DateTime.UtcNow;
    }
}
