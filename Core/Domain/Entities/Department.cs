﻿namespace Domain.Entities
{
    public class Department: Entity
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public int UniversityId { get; set; }
        public University University { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Question> Questions { get; set; }
    }

}
