Feature: Verify user can plan a successful journey with valid locaton entered into the widget

@mytag1
Scenario: Verify that user can plan journey successfully with valid journey location entered into the widget
	Given User is on tfl.gov.uk home page
	And User click on accept all cookies
	When User enter valid location details
		| fromLocation              | toLocation         |
		| Woolwich dockyard station | Paddington station |
	And User click on plan my journey btn
	Then User is presented with the 'Journey results'

@mytag2
Scenario: Verify that the widget is unable to provide results when an invalid journey is planned
	Given User is on tfl.gov.uk home page
	And User click on accept all cookies
	When User enter invalid location details
		| invalidFromLocation | invalidToLocation |
		| goingtosch          | doitright         |
	And User click on plan my journey btn
	Then User is presented with error Message 'Sorry, we can't find a journey matching your criteria'

@mytag3
Scenario: Verify that the widget is unable to plan a journey if no locations are entered into the widget.
	Given User is on tfl.gov.uk home page
	And User click on accept all cookies
	When User enter empty location as details
		| emptyFromLocation | emptyToLocation |
		|                   |                 |
	And User click on plan my journey btn
	Then Error Messages displayed on From and To text field
		| From                        | To                        |
		| The From field is required. | The To field is required. |

@mytag4
Scenario: Verify change time link on the journey planner displays “Arriving” option and plan a journey based on arrival time
	Given User is on tfl.gov.uk home page
	And User click on accept all cookies
	When User click on change time LinkText
	And User verify that Arriving is displayed
	And User click on Arriving
	And User enter valid location details
		| fromLocation             | toLocation         |
		| st pancras international | Paddington station |
	And User click on plan my journey btn
	Then User is presented with the Arriving Journey time

@mytag5
Scenario: Verify that user is able to amend Journey successfully by using the “Edit Journey” button on the Journey results page
	Given User is on tfl.gov.uk home page
	And User click on accept all cookies
	When User enter valid location details
		| fromLocation          | toLocation              |
		| Golders Green station | Stratford international |
	And User click on plan my journey btn
	Then User is presented with the 'Journey results'
	When User click on Edit Journey
	And User enter 'New Cross Gate' as To to update journey
	And User click on updateJourney button
	Then User is presented with updated journey result