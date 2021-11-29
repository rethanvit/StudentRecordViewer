using Microsoft.EntityFrameworkCore;

namespace StudentRecordViewer.DL
{
    public class StudentContext : DbContext, IStudentContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentCredits> StudentCredits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Ignore(c => c.StudentStatus);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = StudentData");
        }
    }
}
