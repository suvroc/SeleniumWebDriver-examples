Feature: Create Doodle feature
	Test should try to add new doodle

@mytag
Scenario: Fill doodle details
	Given Main page is opened
	And I have entered title "Diwebsity test doodle"
	And I have entered name "Diwebsity tester"
	And I have entered email "seleniumTester@diwebsity.com"
	When I press next button
	Then the current url should ends with "/create#dates"
