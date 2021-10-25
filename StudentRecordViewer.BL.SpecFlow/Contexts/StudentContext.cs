using StudentRecordViewer.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRecordViewer.BL.SpecFlow.Contexts
{
    public class StudentContext
    {
        public List<Student> StudentsToBeSetup { get; set; }
        public string StudentProvidedByUser { get; set; }
        public string FeedbackMessage { get; set; }
        public Student SearchedStudent { get; set; }
        public StudentContext()
        {
            StudentsToBeSetup = new List<Student>();
        }
    }
}
