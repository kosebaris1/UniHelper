﻿namespace Domain.Entities
{
    public class Question : Entity
    {
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int UniversityId { get; set; }
        public University University { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public ICollection<QuestionTag> QuestionTags { get; set; }
    }

}
