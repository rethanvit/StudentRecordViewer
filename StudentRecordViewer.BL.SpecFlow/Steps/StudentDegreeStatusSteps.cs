using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentRecordViewer.BL.SpecFlow.Contexts;
using StudentRecordViewer.DL;
using SutdentRecordViewer.BL;
using System;
using TechTalk.SpecFlow;

namespace StudentRecordViewer.BL.SpecFlow.Steps
{
    [Binding]
    [Scope(Feature = "StudentDegreeStatus")]
    public class StudentDegreeStatusSteps
    {
        private readonly StudentSpecContext _studentContext;
        private readonly IStudentDetail _studentRecords;

        public StudentDegreeStatusSteps(StudentSpecContext studentContext, IStudentDetail studentRecords)
        {
            _studentContext = studentContext;
            _studentRecords = studentRecords;
        }

        [Given(@"the student data is available as (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*)")]
        public void GivenTheStudentDataIsAvailableAsJohnStacks(int studentID, string firstName, string lastName, string firstYearCredits, string secondYearCredits, string thirdYearCredits, string fourthYearCredits, string fifthYearCredits)
        {
            var studentToBePopulated = new Student
            {
                StudentId = studentID,
                FirstName = firstName,
                LastName = lastName,
                StudentCredits = new StudentCredits
                {
                    Year1Credits = int.TryParse(firstYearCredits, out int yearOneCredits) ? yearOneCredits : 0,
                    Year2Credits = int.TryParse(secondYearCredits, out int yearTwoCredits) ? yearTwoCredits : 0,
                    Year3Credits = int.TryParse(thirdYearCredits, out int yearThreeCredits) ? yearThreeCredits : 0,
                    Year4Credits = int.TryParse(fourthYearCredits, out int yearFourCredits) ? yearFourCredits : 0,
                    Year5Credits = int.TryParse(fifthYearCredits, out int yearFiveCredits) ? yearFiveCredits : 0
                }
            };

            _studentRecords.StudentRepository = new StudentRespository(new StudentContext());
            _studentRecords.StudentRepository.AddStudent(studentToBePopulated);
        }

        [Given(@"user provides Student ID (.*) who needed only 4 years to complete 160 credits")]
        [Given(@"user provides Student ID (.*) who needed more than 4 years to complete 160 credits")]
        [Given(@"user provides Student ID (.*) who could not complete 160 credits in 5 years")]
        public void GivenUserProvidesStudentIDWhoCouldNotCompleteCreditsInYears(string studentID)
        {
            _studentContext.StudentIdProvidedByUser = studentID;
        }

        [When(@"user search")]
        public void WhenUserSearch()
        {
            try
            {
                var studentIDToBeSearched = _studentContext.StudentIdProvidedByUser?.ToString();
                _studentContext.SearchedStudent = _studentRecords.GetStudent(studentIDToBeSearched);
            }
            catch (Exception ex)
            {
                _studentContext.FeedbackMessage = ex.Message;
            }
        }

        [Then(@"student's status is determined to be ""(.*)""")]
        public void ThenStudentSStatusIsDeterminedToBeExtended(string degreeStatus)
        {
            var studentFound = _studentContext.SearchedStudent;
            Assert.AreEqual(Enum.Parse(typeof(DegreeStatus), degreeStatus).ToString(), studentFound.StudentStatus.ToString());
        }

        [AfterScenario]
        public void CleanupStudent()
        {
            var result = int.TryParse(_studentContext.StudentIdProvidedByUser, out int studentId);
            if(result)
                _studentRecords.StudentRepository.RemoveStudent(studentId);
        }
    }
}
