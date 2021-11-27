using Microsoft.EntityFrameworkCore;

namespace StudentRecordViewer.DL
{
    public interface IStudentContext
    {
        DbSet<Student> Student { get; set; }
        DbSet<StudentCredits> StudentCredits { get; set; }
    }
}