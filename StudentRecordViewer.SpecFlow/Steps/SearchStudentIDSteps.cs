using System;
using TechTalk.SpecFlow;

namespace StudentRecordViewer.SpecFlow.Steps
{
    [Binding]
    public class SearchStudentIDSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public SearchStudentIDSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"the students First name is ""(.*)"" and Last name is ""(.*)""")]
        public void GivenTheStudentsFirstNameIsAndLastNameIs(string p0, string p1)
        {

        }

        [Given(@"the student id is (.*)")]
        public void GivenTheStudentIdIs(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"user provides Student ID (.*)")]
        public void GivenUserProvidesStudentID(int p0)
        {
            ScenarioContext.Current.Pending();
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
        
        [When(@"user searches")]
        public void WhenUserSearches()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"user Search")]
        public void WhenUserSearch()
        {
            ScenarioContext.Current.Pending();
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
