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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ===== Question Config =====
            modelBuilder.Entity<Question>()
                .HasOne(q => q.User)
                .WithMany(u => u.Questions)
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.Restrict); // döngü engeli

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Department)
                .WithMany(d => d.Questions)
                .HasForeignKey(q => q.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade); // bölüm silinirse sorular da gider

            modelBuilder.Entity<Question>()
                .HasOne(q => q.University)
                .WithMany()
                .HasForeignKey(q => q.UniversityId)
                .OnDelete(DeleteBehavior.Restrict); // döngü engeli

            // ===== Answer Config =====
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.User)
                .WithMany(u => u.Answers)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict); // döngü engeli

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade); // soru silinirse cevaplar da gider

            // ===== Department Config =====
            modelBuilder.Entity<Department>()
                .HasOne(d => d.University)
                .WithMany(u => u.Departments)
                .HasForeignKey(d => d.UniversityId)
                .OnDelete(DeleteBehavior.Cascade); // üniversite silinirse bölümler de gider

            // ===== User Config =====
            modelBuilder.Entity<User>()
                .HasOne(u => u.University)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.UniversityId)
                .OnDelete(DeleteBehavior.Restrict); // döngü engeli

            modelBuilder.Entity<User>()
                .HasOne(u => u.Department)
                .WithMany(d => d.Users)
                .HasForeignKey(u => u.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull); // bölüm silinirse kullanıcı boşa düşsün

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.SetNull); // rol silinirse kullanıcı rolü null olsun

            // ===== QuestionTag Config =====
            modelBuilder.Entity<QuestionTag>()
                .HasOne(qt => qt.Question)
                .WithMany(q => q.QuestionTags)
                .HasForeignKey(qt => qt.QuestionId)
                .OnDelete(DeleteBehavior.Cascade); // soru silinirse etiket ilişkileri de gider

            modelBuilder.Entity<QuestionTag>()
                .HasOne(qt => qt.Tag)
                .WithMany(t => t.QuestionTags)
                .HasForeignKey(qt => qt.TagId)
                .OnDelete(DeleteBehavior.Cascade); // etiket silinirse ilişki de silinir
        }


    }
}
