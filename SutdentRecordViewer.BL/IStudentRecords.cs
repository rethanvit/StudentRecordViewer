using StudentRecordViewer.DL;
using System.Collections.Generic;

namespace SutdentRecordViewer.BL
{
    public interface IStudentRecords
    {
        public Student GetStudent(string studentID);
        public int AddStudent(IEnumerable<Student> students);
    }
}