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

        public Student GetStudent(string studentID)
        {
            if(studentID.Length > 6)
                throw new ArgumentException(Constants.InvalidStudentIdMessage);

            bool isValidStudentId = int.TryParse(studentID, out int validStudentId);

            if (!isValidStudentId)
                throw new ArgumentException(Constants.InvalidStudentIdMessage);
            var foundStudent =  _studentRepository.Get(validStudentId);
            return foundStudent ?? throw new KeyNotFoundException(Constants.NonExistentStudent);
        }
    }
}
