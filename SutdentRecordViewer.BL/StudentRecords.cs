using StudentRecordViewer.DL;
using System;
using System.Collections.Generic;

namespace SutdentRecordViewer.BL
{
    public class StudentRecords : IStudentRecords
    {
        private readonly IStudentRepository _studentRepository;

        public StudentRecords(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public int AddStudent(IEnumerable<Student> students)
        {
            return _studentRepository.Add(students);
        }

        public Student GetStudent(int studentID)
        {
            return _studentRepository.Get(studentID);
        }
    }
}
