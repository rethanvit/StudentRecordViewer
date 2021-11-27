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
        private readonly StudentSpecContext _studentSpecContext;
        private readonly IStudentDetail _studentRecords;

        public SearchStudentIDSteps(StudentSpecContext studentContext, IStudentDetail studentRecords)
        {
            _studentSpecContext = studentContext;
            _studentRecords = studentRecords;
        }

        [Given(@"the students First name is ""(.*)"" Last name is ""(.*)"" FirstYearCredits are (.*) SecondYearCredits are (.*) ThirdYearCredits are (.*)")]
        public void GivenTheStudentsFirstNameIsLastNameIsFirstYearCreditsAreSecondYearCreditsAreThirdYearCreditsAreFourthyearCredits(string firstName, string lastName, int firstYearCredits, int secondYearCredits, int thirdYearCredits)
        {
            _studentSpecContext.StudentsToBeSetup = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                StudentCredits = new StudentCredits
                {
                    Year1Credits = firstYearCredits,
                    Year2Credits = secondYearCredits,
                    Year3Credits = thirdYearCredits
                }
            };
        }


        [Given(@"the student id is (.*)")]
        public void GivenTheStudentIdIs(int studentID)
        {
            _studentSpecContext.StudentsToBeSetup.StudentId = studentID;
            _studentRecords.StudentRepository = new StudentRespository(new StudentContext());
            _studentRecords.StudentRepository.AddStudent(_studentSpecContext.StudentsToBeSetup);
        }

        [Given(@"user provides Student ID (.*)")]
        public void GivenUserProvidesStudentID(string invalidStudentId)
        {
            _studentSpecContext.StudentIdProvidedByUser = invalidStudentId;
        }

        [When(@"user search")]
        public void WhenUserSearch()
        {
            try
            {
                var studentIDToBeSearched = _studentSpecContext.StudentIdProvidedByUser?.ToString();
                _studentSpecContext.SearchedStudent = _studentRecords.GetStudent(studentIDToBeSearched);
            }
            catch (Exception ex)
            {
                _studentSpecContext.FeedbackMessage = ex.Message;
            }
        }

        [Given(@"user do not provide a StudentID")]
        public void GivenUserDoNotProvideAStudentID()
        {
            _studentSpecContext.StudentIdProvidedByUser = string.Empty;
        }

        [Then(@"user should see student's First name as ""(.*)"" and Last name as ""(.*)""")]
        public void ThenUserShouldSeeStudentSFirstNameAsAndLastNameAs(string firstName, string lastName)
        {
            var actualStudent = _studentSpecContext.SearchedStudent;
            Assert.AreEqual(firstName, actualStudent.FirstName);
            Assert.AreEqual(lastName, actualStudent.LastName);
        }

        [Then(@"user should get an Error message stating the StudentID is Invalid.")]
        public void ThenUserShouldGetAnErrorMessageStatingTheStudentIDIsInvalid()
        {
            Assert.AreEqual(Constants.InvalidStudentIdMessage, _studentSpecContext.FeedbackMessage);
        }
        
        [Then(@"user should get an error message stating StudentID does not exist\.")]
        public void ThenUserShouldGetAnErrorMessageStatingStudentIDDoesNotExist()
        {
            Assert.AreEqual(Constants.NonExistentStudent, _studentSpecContext.FeedbackMessage);
        }

        [AfterScenario]
        public void CleanupStudent()
        {
           _studentRecords.StudentRepository.RemoveStudent(_studentSpecContext.StudentsToBeSetup.StudentId);
        }
    }
}
