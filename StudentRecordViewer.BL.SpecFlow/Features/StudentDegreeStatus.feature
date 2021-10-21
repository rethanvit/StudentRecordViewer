Feature: StudentDegreeStatus
	
As a Student Record Administrator, when searching a Student ID, 
I want to see student’s degree status so that I know if the student is 
Awarded a degree / awarded an Extended degree / Disqualified.


Scenario Outline: Student's degree status is determined to be Disqualified when 160 credits were not completed in 5 years

Given the student data is available as <StudentID> <FirstName> <LastName> <FirstYearCredits> <SecondYearCredits> <ThirdYearCredits> <FourthYearCredits> <FifthYearCredits>
And user provides Student ID <StudentID> who could not complete 160 credits in 5 years
When user search
Then student's status is determined to be "Disqualified"

Examples:
| StudentID | FirstName | LastName | FirstYearCredits | SecondYearCredits | ThirdYearCredits | FourthYearCredits | FifthYearCredits |
| 134567    | John      | Stacks   | 30               | 40                | 30               | 20                | 0                |
| 145645    | Jack      | Wright   | 40               | 20                | 40               | 0                 | 0                |
| 232334    | Josh      | Monty    | 20               | 40                | 0                |                   |                  |
| 234234    | Jermey    | Clark    | 40               | 40                | 0                | 40                | 0                | 



Scenario Outline: Student's degree status is determined to be Extended on completion of 160 credits, but took more than 4 years

Given the student data is available as <StudentID> <FirstName> <LastName> <FirstYearCredits> <SecondYearCredits> <ThirdYearCredits> <FourthYearCredits> <FifthYearCredits>
And user provides Student ID <StudentID> who needed more than 4 years to complete 160 credits
When user search
Then student's status is determined to be "Extended"

Examples:
| StudentID | FirstName | LastName | FirstYearCredits | SecondYearCredits | ThirdYearCredits | FourthYearCredits | FifthYearCredits |
| 134567    | John      | Stacks   | 30               | 30                | 30               | 30                | 40               |
| 145645    | Jack      | Wright   | 40               | 20                | 20               | 40                | 40               |
| 232334    | Josh      | Monty    | 0                | 40                | 40               | 40                | 40               |
| 234234    | Jermey    | Clark    | 40               | 0                 | 40               | 40                | 40               | 


Scenario Outline: Student's degree status is determined to be Awarded on completion of 160 credits in 4 years

Given the student data is available as <StudentID> <FirstName> <LastName> <FirstYearCredits> <SecondYearCredits> <ThirdYearCredits> <FourthYearCredits> <FifthYearCredits>
And user provides Student ID <StudentID> who needed only 4 years to complete 160 credits
When user search
Then student's status is determined to be "Awarded"

Examples:
| StudentID | FirstName | LastName | FirstYearCredits | SecondYearCredits | ThirdYearCredits | FourthYearCredits | FifthYearCredits |
| 134567    | John      | Stacks   | 40               | 40                | 40               | 40                |                  | 
