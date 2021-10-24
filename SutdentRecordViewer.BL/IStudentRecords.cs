using StudentRecordViewer.DL;
using System.Collections.Generic;

namespace SutdentRecordViewer.BL
{
    public interface IStudentRecords
    {
        IStudentRepository StudentRepository { get; }
        public Student GetStudent(string studentID);
        public IEnumerable<Student> GetAll();
    }
}