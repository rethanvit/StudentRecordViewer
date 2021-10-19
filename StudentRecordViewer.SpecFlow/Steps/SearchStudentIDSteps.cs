using StudentRecordViewer.DL;
using SutdentRecordViewer.BL;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace StudentRecordViewer.SpecFlow.Steps
{
    [Binding]
    public class SearchStudentIDSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IStudentRepository _studentRespository;

        public SearchStudentIDSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _studentRespository = new StudentRespository();
        }

        [Given(@"the students First name is ""(.*)"" and Last name is ""(.*)""")]
        public void GivenTheStudentsFirstNameIsAndLastNameIs(string firstName, string lastName)
        {
            _scenarioContext["StudentRecords"] = new StudentRecords();
            _scenarioContext["Student"] = new Student { FirstName = firstName, LastName = lastName };
        }

        [Given(@"the student id is (.*)")]
        public void GivenTheStudentIdIs(int studentID)
        {
            var student = (Student)_scenarioContext["Student"];
            student.ID = studentID;
            var result = _studentRespository.Add(new List<Student> { student });
        }
        
        [Given(@"user provides Student ID (.*)")]
        public void GivenUserProvidesStudentID(int studentID)
        {
            _scenarioContext["studentIDProvided"] = studentID;
        }

        [Given(@"user provides an Invalid Student ID ""(.*)"" ")]
        public void GivenUserProvidesAnInvalidStudentID(string p0)
        {
            ScenarioContext.Current.Pending();
        }


        [Given(@"user provide a non-existing StudentID for (.*)")]
        public void GivenUserProvideANon_ExistingStudentIDFor(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"user do not provide a StudentID")]
        public void GivenUserDoNotProvideAStudentID()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"user search")]
        public void WhenUserSearch()
        {
            var studentIDToBeSearched = (int)_scenarioContext["studentIDProvided"];
            _scenarioContext["studentFound"] = _studentRespository.Get(studentIDToBeSearched);
        }
        

        [Then(@"user should see student's First name as ""(.*)"" and Last name as ""(.*)""")]
        public void ThenUserShouldSeeStudentSFirstNameAsAndLastNameAs(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"user should get an Error message stating the StudentID is Invalid\.")]
        public void ThenUserShouldGetAnErrorMessageStatingTheStudentIDIsInvalid_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"user should get an error message stating StudentID does not exist\.")]
        public void ThenUserShouldGetAnErrorMessageStatingStudentIDDoesNotExist_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"user should get an error message stating StudentID is empty\.")]
        public void ThenUserShouldGetAnErrorMessageStatingStudentIDIsEmpty_()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
