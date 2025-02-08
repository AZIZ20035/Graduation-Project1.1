using FacultySystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace FacultySystem.Configurations
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FacultySystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>().
                HasKey(s => new { s.Department, s.Level });

            modelBuilder.Entity<QuestionAns>().
              HasKey(s => new { s.QuestionId, s.StudentEmail });

            modelBuilder.Entity<AssignmentAns>().
                      HasKey(s => new { s.QuestionId, s.StudentEmail });
            modelBuilder.Entity<Registeration>().
                HasKey(s => new { s.StaffEmail, s.SubjectDepartment, s.SubjectLevel });
            modelBuilder.Entity<Material>().
                HasKey(s => new { s.StaffEmail, s.SubjectDepartment, s.SubjectLevel });
            modelBuilder.Entity<Post>().
                HasKey(s => new { s.StaffEmail, s.SubjectDepartment, s.SubjectLevel });
            modelBuilder.Entity<Choice>().
                HasKey(s => new { s.QuestionId, s.choice });
            modelBuilder.Entity<Comment>().
                HasKey(s => new { s.PostStaffEmail, s.PostSubjectDepartment, s.PostSubjectLevel, s.Content });
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Exam> Exams { get; set; }

    }
}
