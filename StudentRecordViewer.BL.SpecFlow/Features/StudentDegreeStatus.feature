Feature: StudentDegreeStatus
	As a Student Record Administrator, when searching a Student ID, I want to see student’s degree status so that I know if the student is Awarded a degree / awarded an Extended degree / Disqualified.

Background: 
Given Following is the list of student data available

| StudentID | FirstName | LastName | FirstYearCredits | SecondYearCredits | ThirdYearCredits | FourthYearCredits | FifthYearCredits |
| 134567    | John      | Stacks   | 30               | 40                | 40               | 10                | 40               |
| 145645    | Jack      | Wright   | 40               | 30                | 40               | 10                | 40               |
| 232334    | Josh      | Monty    | 20               | 40                | 0                |                   |                  |
| 234234    | Jermey    | Clark    | 40               | 40                | 40               | 40                |                  |
| 456456    | Mike      | Stacy    | 30               | 30                | 0                |                   |                  |
| 345345    | Kelly     | Caster   | 40               | 0                 |   30             | 40                |                  |
| 345348    | Stella    | Caster   | 40               | 0                 |   30             | 40                | 40               |


Scenario Outline: Student's degree status is determined based on the credits completed
Given user provides Student ID <StudentID> 
When user search
Then student's status is determined to be <DegreeStatus>

Examples:
| StudentID | DegreeStatus |
| 134567    | Extended     |
| 145645    | Extended     |
| 232334    | Disqualified |
| 234234    | Awarded      |
| 456456    | Disqualified |
| 345345    | Disqualified |
| 345348    | Disqualified |