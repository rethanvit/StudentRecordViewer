using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentRecordViewer.DL
{
    public class StudentRespository : IStudentRepository
    {
        public List<Student> AllStudents { get; set; }

        public StudentRespository()
        {

        }

        public Student Get(int studentIDToBeSearched)
        {
            return AllStudents.SingleOrDefault(s => s.ID == studentIDToBeSearched);
        }

        IEnumerable<Student> IStudentRepository.GetAll()
        {
            return AllStudents;
        }
    }

    public interface IStudentRepository
    {
        List<Student> AllStudents { get; set; }
        Student Get(int studentIDToBeSearched);
        IEnumerable<Student> GetAll();
    }


}
