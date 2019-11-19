Feature: SaveTextInNotepad
	In order to save a content in Notepad
	As a windows user
	I want to enter content and save it

@mytag
Scenario: SaveTextInNotepad
	Given I have entered new content in opened notepad
	When I save it
	Then the Notepad must save in the default location
