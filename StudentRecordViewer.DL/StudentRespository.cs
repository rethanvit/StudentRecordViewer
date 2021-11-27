using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentRecordViewer.DL
{
    public class StudentRespository : IStudentRepository
    {
        private readonly StudentContext studentContext;

        public StudentRespository()
        {

        }
        public StudentRespository(StudentContext studentContext)
        {
            this.studentContext = studentContext;
        }

        public Student Get(int studentIDToBeSearched)
        {
            return studentContext.Student.SingleOrDefault(s => s.StudentId == studentIDToBeSearched);
        }

        IEnumerable<Student> IStudentRepository.GetAll()
        {
            return studentContext.Student.ToList();
        }

        public StudentCredits GetStudentCredits(int studentCreditsId)
        {
            return studentContext.StudentCredits.SingleOrDefault(c => c.StudentCreditsId == studentCreditsId);
        }

        public int AddStudent(Student student)
        {
            try
            {
                studentContext.Student.Add(student);
                var result = studentContext.SaveChanges();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int RemoveStudent(int studentId)
        {
            var student = studentContext.Student.Where(s => s.StudentId == studentId).Include(c => c.StudentCredits).SingleOrDefault();
            studentContext.Remove(student);
            return studentContext.SaveChanges();
        }
    }

    public interface IStudentRepository
    {
        Student Get(int studentIDToBeSearched);
        StudentCredits GetStudentCredits(int studentCreditsId);
        int AddStudent(Student student);
        int RemoveStudent(int studentId);
        IEnumerable<Student> GetAll();
    }
}
