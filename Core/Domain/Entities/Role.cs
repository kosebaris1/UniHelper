namespace Domain.Entities
{
    public class Role : Entity
    {
        public int RoleId { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }

}
