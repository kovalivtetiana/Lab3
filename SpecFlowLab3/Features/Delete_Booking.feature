Feature: Delete_Booking
	
Scenario: Delete booking 
	When call request to delete a record
	Then The response status code should be Created