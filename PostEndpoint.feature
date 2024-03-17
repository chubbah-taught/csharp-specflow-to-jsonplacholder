Feature: As a user I want to send and evaluate POST requests at "https://jsonplaceholder.typicode.com/posts"

Scenario: I can successfully create new entries with POST request
	Given  I prepare a new entry to be sent
	When I send the new entry with POST
	Then the request is successful
	And the data on the server matches with the data that was originally sent