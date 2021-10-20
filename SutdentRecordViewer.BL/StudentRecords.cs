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

            if(foundStudent != null)
                foundStudent.StudentStatus = DetermineDegreeStatus(foundStudent);

            return foundStudent ?? throw new KeyNotFoundException(Constants.NonExistentStudent);
        }

        private DegreeStatus DetermineDegreeStatus(Student foundStudent)
        {
            var totalCreditsCompleted = foundStudent.Year1Credits + foundStudent.Year2Credits + foundStudent.Year3Credits + foundStudent.Year4Credits + foundStudent.Year5Credits;
            
            if (totalCreditsCompleted < Constants.TotalCreditsAllowed)
            {
                foundStudent.StudentStatus = DegreeStatus.Disqualified;
            }
            else if (totalCreditsCompleted - foundStudent.Year5Credits - foundStudent.Year4Credits < 120 && totalCreditsCompleted - foundStudent.Year5Credits == 120)
            {
                foundStudent.StudentStatus = DegreeStatus.Extended;
            }
            else if (totalCreditsCompleted - foundStudent.Year5Credits == Constants.TotalCreditsAllowed)
            {
                foundStudent.StudentStatus = DegreeStatus.Awarded;
            }

            return foundStudent.StudentStatus;
        }
    }
}
