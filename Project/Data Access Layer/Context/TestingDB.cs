using Data_Access_Layer.Context.Initializer;
using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Context
{
    public class TestingDB : DbContext
    {
        public TestingDB(DbContextOptions<TestingDB> options) : base(options)
        {
            Database.EnsureCreated();
            TestingInitializer.Initialize(this);
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Completed> Completeds { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
              .HasOne(x => x.Question)
              .WithMany(x => x.Answers)
              .HasForeignKey(x => x.QuestionId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Question>()
              .HasOne(x => x.Test)
              .WithMany(x => x.Questions)
              .HasForeignKey(x => x.TestId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Test>()
              .HasMany(x => x.Completeds)
              .WithOne(x => x.Test)
              .HasForeignKey(x => x.TestId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Test>()
             .HasOne(x => x.Teacher)
             .WithMany(x => x.Tests)
             .HasForeignKey(x => x.TeacherId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Student>()
             .HasMany(x => x.Completeds)
             .WithOne(x => x.Student)
             .HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Completed>()
             .HasMany(x => x.Results)
             .WithOne(x => x.Completed)
             .HasForeignKey(x => x.CompletedId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}