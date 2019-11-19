Feature: GetTimeDateAndSaveInNotepad
	In order to get the current Time/Date
	via Notepad

@mytag
Scenario: GetTimeDateAndCloseNotepad
	Given I have clicked Edit in Menu 
	When the Edit menu is expanded 
	And Click Time/Date to see current Date and Time
	Then Close the Notepad without saving it
