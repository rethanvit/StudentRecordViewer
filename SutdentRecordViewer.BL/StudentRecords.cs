using StudentRecordViewer.DL;
using System;
using System.Collections.Generic;

namespace SutdentRecordViewer.BL
{
    public class StudentDetail : IStudentDetail
    {
        public IStudentRepository StudentRepository { get; set; }

        public StudentDetail(IStudentRepository studentRepository)
        {
            StudentRepository = studentRepository;
        }
        public IEnumerable<Student> GetAll()
        {
            return StudentRepository.GetAll();
        }

        public Student GetStudent(string studentID)
        {
            if(studentID.Length > 6)
                throw new ArgumentException(Constants.InvalidStudentIdMessage);

            bool isValidStudentId = int.TryParse(studentID, out int validStudentId);

            if (!isValidStudentId)
                throw new ArgumentException(Constants.InvalidStudentIdMessage);

            var foundStudent = StudentRepository.Get(validStudentId);

            if(foundStudent != null)
            {
                var studentCredits = StudentRepository.GetStudentCredits(foundStudent.StudentCreditsId);
                foundStudent.StudentStatus = DetermineDegreeStatus(foundStudent, studentCredits);
            }

            return foundStudent ?? throw new KeyNotFoundException(Constants.NonExistentStudent);
        }

        private DegreeStatus DetermineDegreeStatus(Student foundStudent, StudentCredits studentCredits)
        {
            var totalCreditsCompleted = studentCredits.Year1Credits + studentCredits.Year2Credits + studentCredits.Year3Credits + studentCredits.Year4Credits + studentCredits.Year5Credits;

            if (totalCreditsCompleted < Constants.TotalCreditsAllowed)
            {
                foundStudent.StudentStatus = DegreeStatus.Disqualified;
            }
            else if (totalCreditsCompleted - studentCredits.Year5Credits - studentCredits.Year4Credits < 120 && totalCreditsCompleted - studentCredits.Year5Credits == 120)
            {
                foundStudent.StudentStatus = DegreeStatus.Extended;
            }
            else if (totalCreditsCompleted - studentCredits.Year5Credits == Constants.TotalCreditsAllowed)
            {
                foundStudent.StudentStatus = DegreeStatus.Awarded;
            }

            return foundStudent.StudentStatus;
        }
    }
}
