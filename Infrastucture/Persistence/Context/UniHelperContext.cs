using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class UniHelperContext : DbContext
    {
        public UniHelperContext(DbContextOptions<UniHelperContext> options) : base(options) { }




        public DbSet<User> Users { get; set; }
        public DbSet<University> Universitites { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionTag> QuestionTags { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuestionLike> QuestionLikes { get; set; }
        public DbSet<AnswerLike> AnswerLikes { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Notification> Notifications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Question → User
            modelBuilder.Entity<Question>()
                .HasOne(q => q.User)
                .WithMany(u => u.Questions)
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // User → Department
            //modelBuilder.Entity<User>()
            //    .HasOne(u => u.Department)
            //    .WithMany(d => d.Users)
            //    .HasForeignKey(u => u.DepartmentId)
            //    .OnDelete(DeleteBehavior.SetNull);

            // User → University
            //modelBuilder.Entity<User>()
            //    .HasOne(u => u.University)
            //    .WithMany(u => u.Users)
            //    .HasForeignKey(u => u.UniversityId)
            //    .OnDelete(DeleteBehavior.Restrict);

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

            // University → City
            modelBuilder.Entity<University>()
                .HasOne(u => u.City)
                .WithMany(c => c.Universities)
                .HasForeignKey(u => u.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            // QuestionLike composite key
            modelBuilder.Entity<QuestionLike>()
                .HasKey(ql => new { ql.UserId, ql.QuestionId });

            // QuestionLike relationships
            modelBuilder.Entity<QuestionLike>()
                .HasOne(ql => ql.User)
                .WithMany(u => u.LikedQuestions)
                .HasForeignKey(ql => ql.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<QuestionLike>()
                .HasOne(ql => ql.Question)
                .WithMany(q => q.QuestionLikes)
                .HasForeignKey(ql => ql.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            // AnswerLike composite key
            modelBuilder.Entity<AnswerLike>()
                .HasKey(al => new { al.UserId, al.AnswerId });

            // AnswerLike relationships
            modelBuilder.Entity<AnswerLike>()
                .HasOne(al => al.User)
                .WithMany(u => u.LikedAnswers)
                .HasForeignKey(al => al.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AnswerLike>()
                .HasOne(al => al.Answer)
                .WithMany(a => a.AnswerLikes)
                .HasForeignKey(al => al.AnswerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Report → User
            modelBuilder.Entity<Report>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reports)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Report → Question
            modelBuilder.Entity<Report>()
                .HasOne(r => r.Question)
                .WithMany(q => q.Reports)
                .HasForeignKey(r => r.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Report → Answer
            modelBuilder.Entity<Report>()
                .HasOne(r => r.Answer)
                .WithMany(a => a.Reports)
                .HasForeignKey(r => r.AnswerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    }
