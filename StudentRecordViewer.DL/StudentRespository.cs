using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentRecordViewer.DL
{
    public class StudentRespository : IStudentRepository
    {
        private List<Student> AllStudents { get; set; }
        public StudentRespository()
        {
            AllStudents = GetAll();
        }

        public int Add(IEnumerable<Student> students)
        {
            AllStudents.AddRange(students);
            return students.Count();
        }

        public Student Get(int studentIDToBeSearched)
        {
            return AllStudents.SingleOrDefault(s => s.ID == studentIDToBeSearched);
        }

        private List<Student> GetAll()
        {
            return new List<Student>{
                //new Student { ID = 1122, FirstName = "F1122", LastName="L1122"},
                //new Student { ID = 2233, FirstName = "F2233", LastName="L2233"},
                //new Student { ID = 3344, FirstName = "F3344", LastName="L3344"},
                //new Student { ID = 5566, FirstName = "F5566", LastName="L5566"},
                //new Student { ID = 7788, FirstName = "F7788", LastName="L7788"}
            };
        }
    }

    public interface IStudentRepository
    {
        public int Add(IEnumerable<Student> students);
        Student Get(int studentIDToBeSearched);
    }


}
