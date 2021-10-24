using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentRecordViewer.DL;
using SutdentRecordViewer.BL;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace StudentRecordViewer.BL.SpecFlow.Steps
{
    [Binding]
    [Scope(Feature = "StudentDegreeStatus")]
    public class StudentDegreeStatusSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IStudentRecords _studentRecords;

        public StudentDegreeStatusSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _studentRecords = new StudentRecords(new StudentRespository());
        }

        //[Given(@"the student data is available as shown")]
        //public void GivenFollowingIsTheListOfStudentDataIsAvailable(Table table)
        //{
        //    var studentsToBePopulated = new List<Student>();
        //    foreach (var row in table.Rows)
        //    {
        //        studentsToBePopulated.Add(new Student
        //        {
        //            ID = int.Parse(row[0]),
        //            FirstName = row[1],
        //            LastName = row[2],
        //            Year1Credits = int.TryParse(row[3], out int firstYearCredits) ? firstYearCredits : 0,
        //            Year2Credits = int.TryParse(row[4], out int secondYearCredits) ? secondYearCredits : 0,
        //            Year3Credits = int.TryParse(row[5], out int thirdYearCredits) ? thirdYearCredits : 0,
        //            Year4Credits = int.TryParse(row[6], out int fourthYearCredits) ? fourthYearCredits : 0,
        //            Year5Credits = int.TryParse(row[7], out int fifthYearCredits) ? fifthYearCredits : 0,
        //        });
        //    }
        //    _studentRecords.AddStudent(studentsToBePopulated);
        //}

        [Given(@"the student data is available as (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*)")]
        public void GivenTheStudentDataIsAvailableAsJohnStacks(int studentID, string firstName, string lastName, string firstYearCredits, string secondYearCredits, string thirdYearCredits, string fourthYearCredits, string fifthYearCredits)
        {
            var studentsToBePopulated = new List<Student>
            {
                new Student
                {
                    ID = studentID,
                    FirstName = firstName,
                    LastName = lastName,
                    Year1Credits = int.TryParse(firstYearCredits, out int yearOneCredits) ? yearOneCredits : 0,
                    Year2Credits = int.TryParse(secondYearCredits, out int yearTwoCredits) ? yearTwoCredits : 0,
                    Year3Credits = int.TryParse(thirdYearCredits, out int yearThreeCredits) ? yearThreeCredits : 0,
                    Year4Credits = int.TryParse(fourthYearCredits, out int yearFourCredits) ? yearFourCredits : 0,
                    Year5Credits = int.TryParse(fifthYearCredits, out int yearFiveCredits) ? yearFiveCredits : 0,
                }
            };
            _studentRecords.StudentRepository.AllStudents = studentsToBePopulated;
        }

        [Given(@"user provides Student ID (.*) who needed only 4 years to complete 160 credits")]
        [Given(@"user provides Student ID (.*) who needed more than 4 years to complete 160 credits")]
        [Given(@"user provides Student ID (.*) who could not complete 160 credits in 5 years")]
        public void GivenUserProvidesStudentIDWhoCouldNotCompleteCreditsInYears(int studentID)
        {
            _scenarioContext["studentIDProvided"] = studentID;
        }

        [When(@"user search")]
        public void WhenUserSearch()
        {
            try
            {
                var studentIDToBeSearched = _scenarioContext["studentIDProvided"]?.ToString();
                _scenarioContext["studentRecordFound"] = _studentRecords.GetStudent(studentIDToBeSearched);
            }
            catch (Exception ex)
            {
                _scenarioContext["errorMessage"] = ex.Message;
            }
        }


        [Then(@"student's status is determined to be ""(.*)""")]
        public void ThenStudentSStatusIsDeterminedToBeExtended(string degreeStatus)
        {
            var studentFound= (Student)_scenarioContext["studentRecordFound"];
            Assert.AreEqual(Enum.Parse(typeof(DegreeStatus), degreeStatus).ToString(), studentFound.StudentStatus.ToString());
        }

    }
}
