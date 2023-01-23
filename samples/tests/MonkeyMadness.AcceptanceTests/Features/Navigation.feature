Feature: Navigation

The application can navigate to all the views.

Scenario: The active view is null before startup
	Given the application is not started
	Then the active view will be null

Scenario: The active view is 'Main' after startup
	Given the application is started
	Then the active view will be the 'Main' view

Scenario: The active view is 'MonkeyDetails' after the `GoToDetailsCommand` is executed
   Given the application is started
     And the active view is the 'Main' view
    When the user requests to go to the details for a monkey
    Then the active view will be the 'MonkeyDetails' view
