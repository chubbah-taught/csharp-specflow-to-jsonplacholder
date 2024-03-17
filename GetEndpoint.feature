Feature: As a user I want to send and evaluate GET requests at "https://jsonplaceholder.typicode.com/posts"
    
Scenario: When I call the GET endpoint it responds with success code
        Given I send a GET request to GET endpoint
        Then the GET request responds with success status code

    Scenario: All "userID" field type is INT
        Given I send a GET request to GET endpoint
        When I evaluate all userID fields
        Then all userID field's type is INT
    
    Scenario: All "id" field type is INT
        Given I send a GET request to GET endpoint
        When I evaluate all ID fields
        Then all ID field's type is int

    Scenario: All title field type is STRING
        Given I send a GET request to GET endpoint
        When I evaluate all title field
        Then all title field's type is STRING

    Scenario: All body field type is STRING
        Given I send a GET request to GET endpoint
        When I evaluate all body field
        Then all body field's type is STRING

    Scenario: The total number of records equal to 100
        Given I send a GET request to GET endpoint
        When I evaluate the number of fields
        Then the total number of fields equal to 100