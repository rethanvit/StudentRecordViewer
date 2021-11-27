using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
