namespace Domain.Entities
{
    public class University : Entity
    {
        public int UniversityId { get; set; }
        public string Name { get; set; }
        public int? CityId { get; set; }
        public City? City { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<User> Users { get; set; }
    }

}
