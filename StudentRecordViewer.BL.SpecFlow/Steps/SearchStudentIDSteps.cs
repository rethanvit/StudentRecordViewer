using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentRecordViewer.DL;
using SutdentRecordViewer.BL;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace StudentRecordViewer.BL.SpecFlow.Steps
{
    [Binding]
    [Scope(Feature = "SearchStudentID")]
    public class SearchStudentIDSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IStudentRecords _studentRecords;

        public SearchStudentIDSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _studentRecords = new StudentRecords(new StudentRespository());
        }

        [Given(@"the students First name is ""(.*)"" and Last name is ""(.*)""")]
        public void GivenTheStudentsFirstNameIsAndLastNameIs(string firstName, string lastName)
        {
            _scenarioContext["Student"] = new Student { FirstName = firstName, LastName = lastName };
        }

        [Given(@"the student id is (.*)")]
        public void GivenTheStudentIdIs(int studentID)
        {
            var student = (Student)_scenarioContext["Student"];
            student.ID = studentID;
            _studentRecords.StudentRepository.AllStudents = new List<Student> { student };
        }

        [Given(@"user provides Student ID (.*)")]
        public void GivenUserProvidesStudentID(string invalidStudentId)
        {
            _scenarioContext["studentIDProvided"] = invalidStudentId;
        }

        [When(@"user search")]
        public void WhenUserSearch()
        {
            try
            {
                var studentIDToBeSearched = _scenarioContext["studentIDProvided"]?.ToString();
                _scenarioContext["studentFound"] = _studentRecords.GetStudent(studentIDToBeSearched);
            }
            catch (Exception ex)
            {
                _scenarioContext["errorMessage"] = ex.Message;
            }
        }

        [Given(@"user do not provide a StudentID")]
        public void GivenUserDoNotProvideAStudentID()
        {
            _scenarioContext["studentIDProvided"] = string.Empty;
        }

        [Then(@"user should see student's First name as ""(.*)"" and Last name as ""(.*)""")]
        public void ThenUserShouldSeeStudentSFirstNameAsAndLastNameAs(string firstName, string lastName)
        {
            var actualStudent = (Student)_scenarioContext["studentFound"];
            Assert.AreEqual(firstName, actualStudent.FirstName);
            Assert.AreEqual(lastName, actualStudent.LastName);
        }

        [Then(@"user should get an Error message stating the StudentID is Invalid.")]
        public void ThenUserShouldGetAnErrorMessageStatingTheStudentIDIsInvalid()
        {
            Assert.AreEqual(Constants.InvalidStudentIdMessage, (string)_scenarioContext["errorMessage"]);
        }
        
        [Then(@"user should get an error message stating StudentID does not exist\.")]
        public void ThenUserShouldGetAnErrorMessageStatingStudentIDDoesNotExist()
        {
            Assert.AreEqual(Constants.NonExistentStudent, (string)_scenarioContext["errorMessage"]);
        }
    }
}
