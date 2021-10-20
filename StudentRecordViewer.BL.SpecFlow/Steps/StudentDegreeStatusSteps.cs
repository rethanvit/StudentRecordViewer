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

        [Given(@"Following is the list of student data available")]
        public void GivenFollowingIsTheListOfStudentDataIsAvailable(Table table)
        {
            var studentsToBePopulated = new List<Student>();
            foreach (var row in table.Rows)
            {
                studentsToBePopulated.Add(new Student
                {
                    ID = int.Parse(row[0]),
                    FirstName = row[1],
                    LastName = row[2],
                    Year1Credits = int.TryParse(row[3], out int firstYearCredits) ? firstYearCredits : 0,
                    Year2Credits = int.TryParse(row[4], out int secondYearCredits) ? secondYearCredits : 0,
                    Year3Credits = int.TryParse(row[5], out int thirdYearCredits) ? thirdYearCredits : 0,
                    Year4Credits = int.TryParse(row[6], out int fourthYearCredits) ? fourthYearCredits : 0,
                    Year5Credits = int.TryParse(row[7], out int fifthYearCredits) ? fifthYearCredits : 0,
                });
            }
            _studentRecords.AddStudent(studentsToBePopulated);
        }

        [Given(@"user provides Student ID (.*)")]
        public void GivenUserProvides(int studentID)
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


        [Then(@"student's status is determined to be (.*)")]
        public void ThenStudentSStatusIsDeterminedToBeExtended(string degreeStatus)
        {
            var studentFound= (Student)_scenarioContext["studentFound"];
            Assert.AreEqual(Enum.Parse(typeof(DegreeStatus), degreeStatus).ToString(), studentFound.StudentStatus.ToString());
        }

    }
}
