using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentRecordViewer.DL;
using SutdentRecordViewer.BL;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace StudentRecordViewer.BL.SpecFlow.Steps
{
    [Binding]
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
            var result = _studentRecords.AddStudent(new List<Student> { student });
        }
        
        [Given(@"user provides Student ID (.*)")]
        public void GivenUserProvidesStudentID(int studentID)
        {
            _scenarioContext["studentIDProvided"] = studentID;
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

        [Given(@"user provides an Invalid Student ID (.*)")]
        public void GivenUserProvidesAnInvalidStudentID(string invalidStudentID)
        {
            _scenarioContext["studentIDProvided"] = invalidStudentID;
        }

        [Given(@"user provide a non-existing StudentID (.*)")]
        public void GivenUserProvideANon_ExistingStudentIDFor(int studentID)
        {
            _scenarioContext["studentIDProvided"] = studentID;
        }
        
        [Given(@"user do not provide a StudentID")]
        public void GivenUserDoNotProvideAStudentID()
        {
            _scenarioContext["studentIDProvided"] = string.Empty;
        }

        [Then(@"user should see student's First name as ""(.*)"" and Last name as ""(.*)""")]
        public void ThenUserShouldSeeStudentSFirstNameAsAndLastNameAs(string firstName, string lastName)
        {
            var expectStudent = new Student { FirstName = firstName, LastName = lastName, ID = (int)_scenarioContext["studentIDProvided"] };
            var actualStudent = (Student)_scenarioContext["studentFound"];
            expectStudent.Should().BeEquivalentTo(actualStudent);
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
