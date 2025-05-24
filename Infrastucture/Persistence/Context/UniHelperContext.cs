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
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionTag> QuestionTags { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Question → User
            modelBuilder.Entity<Question>()
                .HasOne(q => q.User)
                .WithMany(u => u.Questions)
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //// Question → Department (opsiyonel)
            //modelBuilder.Entity<Question>()
            //    .HasOne(q => q.Department)
            //    .WithMany(d => d.Questions)
            //    .HasForeignKey(q => q.DepartmentId)
            //    .OnDelete(DeleteBehavior.SetNull);

            //// Question → University (opsiyonel)
            //modelBuilder.Entity<Question>()
            //    .HasOne(q => q.University)
            //    .WithMany(u => u.Questions)
            //    .HasForeignKey(q => q.UniversityId)
            //    .OnDelete(DeleteBehavior.SetNull);

            // User → Department
            modelBuilder.Entity<User>()
                .HasOne(u => u.Department)
                .WithMany(d => d.Users)
                .HasForeignKey(u => u.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasOne(u => u.University)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.UniversityId)
                .OnDelete(DeleteBehavior.Restrict); // ✅ ÇAKIŞMA YOK


            // User → Role
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.SetNull);

            // Answer → Question
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Answer → User
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.User)
                .WithMany(u => u.Answers)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // QuestionTag → Question
            modelBuilder.Entity<QuestionTag>()
                .HasOne(qt => qt.Question)
                .WithMany(q => q.QuestionTags)
                .HasForeignKey(qt => qt.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            // QuestionTag → Tag
            modelBuilder.Entity<QuestionTag>()
                .HasOne(qt => qt.Tag)
                .WithMany(t => t.QuestionTags)
                .HasForeignKey(qt => qt.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<University>()
                .HasOne(u => u.City)
                .WithMany(c => c.Universities)
                .HasForeignKey(u => u.CityId)
                .OnDelete(DeleteBehavior.Restrict); // ya da SetNull

        }



    }
}
