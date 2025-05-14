using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class UniHelperContext : DbContext
    {
        public UniHelperContext(DbContextOptions<UniHelperContext> options):base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<University> Universitites { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Question> Questşons { get; set; }
        public DbSet<QuestionTag> QuestionTags { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
