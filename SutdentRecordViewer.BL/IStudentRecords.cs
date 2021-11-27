using StudentRecordViewer.DL;
using System.Collections.Generic;

namespace SutdentRecordViewer.BL
{
    public interface IStudentDetail
    {
        IStudentRepository StudentRepository { get; set; }
        public Student GetStudent(string studentID);
        public IEnumerable<Student> GetAll();
    }
}