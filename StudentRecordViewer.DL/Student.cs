using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRecordViewer.DL
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentCreditsId { get; set; }
        public StudentCredits StudentCredits { get; set; }
        public DegreeStatus StudentStatus { get; set; }
    }

    public class StudentCredits
    {
        public int StudentCreditsId { get; set; }
        public int Year1Credits { get; set; }
        public int Year2Credits { get; set; }
        public int Year3Credits { get; set; }
        public int Year4Credits { get; set; }
        public int Year5Credits { get; set; }
        public Student Student { get; set; }
    }
}
