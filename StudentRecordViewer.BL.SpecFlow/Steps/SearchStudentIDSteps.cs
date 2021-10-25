using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentRecordViewer.BL.SpecFlow.Contexts;
using StudentRecordViewer.DL;
using SutdentRecordViewer.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace StudentRecordViewer.BL.SpecFlow.Steps
{
    [Binding]
    [Scope(Feature = "SearchStudentID")]
    public class SearchStudentIDSteps
    {
        private readonly StudentContext _studentContext;
        private readonly IStudentRecords _studentRecords;

        public SearchStudentIDSteps(StudentContext studentContext, IStudentRecords studentRecords)
        {
            _studentContext = studentContext;
            _studentRecords = studentRecords;
        }

        [Given(@"the students First name is ""(.*)"" and Last name is ""(.*)""")]
        public void GivenTheStudentsFirstNameIsAndLastNameIs(string firstName, string lastName)
        {
            _studentContext.StudentsToBeSetup.Add(new Student { FirstName = firstName, LastName = lastName });
        }

        [Given(@"the student id is (.*)")]
        public void GivenTheStudentIdIs(int studentID)
        {
            _studentContext.StudentsToBeSetup.Single().ID = studentID;
            _studentRecords.StudentRepository.AllStudents = _studentContext.StudentsToBeSetup;
        }

        [Given(@"user provides Student ID (.*)")]
        public void GivenUserProvidesStudentID(string invalidStudentId)
        {
            _studentContext.StudentProvidedByUser = invalidStudentId;
        }

        [When(@"user search")]
        public void WhenUserSearch()
        {
            try
            {
                var studentIDToBeSearched = _studentContext.StudentProvidedByUser?.ToString();
                _studentContext.SearchedStudent = _studentRecords.GetStudent(studentIDToBeSearched);
            }
            catch (Exception ex)
            {
                _studentContext.FeedbackMessage = ex.Message;
            }
        }

        [Given(@"user do not provide a StudentID")]
        public void GivenUserDoNotProvideAStudentID()
        {
            _studentContext.StudentProvidedByUser = string.Empty;
        }

        [Then(@"user should see student's First name as ""(.*)"" and Last name as ""(.*)""")]
        public void ThenUserShouldSeeStudentSFirstNameAsAndLastNameAs(string firstName, string lastName)
        {
            var actualStudent = _studentContext.SearchedStudent;
            Assert.AreEqual(firstName, actualStudent.FirstName);
            Assert.AreEqual(lastName, actualStudent.LastName);
        }

        [Then(@"user should get an Error message stating the StudentID is Invalid.")]
        public void ThenUserShouldGetAnErrorMessageStatingTheStudentIDIsInvalid()
        {
            Assert.AreEqual(Constants.InvalidStudentIdMessage, _studentContext.FeedbackMessage);
        }
        
        [Then(@"user should get an error message stating StudentID does not exist\.")]
        public void ThenUserShouldGetAnErrorMessageStatingStudentIDDoesNotExist()
        {
            Assert.AreEqual(Constants.NonExistentStudent, _studentContext.FeedbackMessage);
        }
    }
}
