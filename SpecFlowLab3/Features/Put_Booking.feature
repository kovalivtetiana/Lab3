Feature: Put_Booking

Scenario: Update booking 
	When send update booking request
	Then response status code should be OK