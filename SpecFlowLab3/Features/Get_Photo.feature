Feature: Get_Photo

Scenario: Get photo id 10
	When sending a request to read photo from id
	Then the response status code should be OK