Feature: Get_Booking

Scenario: Read booking
	When send read booking request
	Then The response status code should be OK