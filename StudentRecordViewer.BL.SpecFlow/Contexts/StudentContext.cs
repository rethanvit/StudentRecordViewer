using StudentRecordViewer.DL;

namespace StudentRecordViewer.BL.SpecFlow.Contexts
{
    public class StudentSpecContext
    {
        public Student StudentsToBeSetup { get; set; }
        public string StudentIdProvidedByUser { get; set; }
        public string FeedbackMessage { get; set; }
        public Student SearchedStudent { get; set; }
        public StudentSpecContext()
        {
            StudentsToBeSetup = new Student();
        }
    }
}
