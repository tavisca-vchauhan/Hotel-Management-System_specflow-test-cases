Feature: Add hotel
	In order to simulate hotel management system
	As api consumer
	I want to be able to add hotel,get hotel details and book hotel

@GetHotelById
Scenario Outline: User get the details of hotel by Id
	Given User provided valid Id '<id>'  and '<name>'for hotel 
	And Use has added required details for hotel
	When User calls AddHotel api
	When User calls Get_Hotel_By_Id '<id>' api
	Then Hotel with id '<id>' should be displayed in the response
Examples: 
| id | name   |
| 1  | hotel1 |
| 2  | hotel2 |
| 3  | hotel3 |
| 4  | hotel4 |


@myHotelList
Scenario: User retrieves the list of all hotels
	When User calls List_Of_Hotel api
	Then All Hotels should be displayed in the response
	

@GetHotelById
Scenario: User get the list of all hotels added
	Given User provided valid Id '5'  and 'hotel_5'for hotel 
	And Use has added required details for hotel
	And User call AddHotel api
	And User provided valid Id '6'  and 'hotel_6'for hotel
	And Use has added required details for hotel
	And User call AddHotel api
	And User provided valid Id '7'  and 'hotel_7'for hotel
	And Use has added required details for hotel
	And User call AddHotel api
	And User provided valid Id '8'  and 'hotel_8'for hotel
	And Use has added required details for hotel
	And User call AddHotel api
	When User calls List_Of_Hotel api
	Then All Hotels should be displayed in the response


