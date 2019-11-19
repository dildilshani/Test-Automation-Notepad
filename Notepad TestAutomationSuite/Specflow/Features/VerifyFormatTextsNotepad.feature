Feature: VerifyFormatTextsNotepad
	In order to check different formats in text in Notepad

@mytag
Scenario: VerifyFormatTextsNotepad
	Given I have entered text in text editor
	And press Format button on menu
	When I change different formats 
	Then text dispaly with relevant format and close notepad
