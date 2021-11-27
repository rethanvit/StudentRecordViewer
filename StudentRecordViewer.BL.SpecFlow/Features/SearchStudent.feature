Feature: SearchStudentID
#Probably hooks might be better idea to be used rather than background here. 
Background:
Given the students First name is "Jane" Last name is "Smith" FirstYearCredits are 30 SecondYearCredits are 30 ThirdYearCredits are 30
And the student id is 342232

Scenario: Get First and Last Name for a Valid StudentID
Given user provides Student ID 342232
When user search
Then user should see student's First name as "Jane" and Last name as "Smith"

Scenario Outline: Get error for an Invalid StudentID

Given user provides Student ID <InvalidStudentId>
When user search
Then user should get an Error message stating the StudentID is Invalid.

Examples:
| InvalidStudentId |
|  ABD234X         |
|  aa  3433b       |
| 32123 23         |
| 332323221        |

Scenario: Get error for an non-existing StudentID
Given user provides Student ID 123456
When user search
Then user should get an error message stating StudentID does not exist.

Scenario: Get error for empty StudentID
Given user do not provide a StudentID
When user search
Then user should get an Error message stating the StudentID is Invalid.
