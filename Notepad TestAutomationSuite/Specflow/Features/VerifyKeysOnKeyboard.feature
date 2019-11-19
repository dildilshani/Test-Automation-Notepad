Feature: VerifyKeysOnKeyboard
	Verify keybaord shortcut keys on Notepad

@mytag
Scenario: VerifyKeysOnKeyboard
	Given I have typed something on text editor
	And select the text using Ctrl+A keyboard shortcut
	And copy the text using Ctrl+C keyboard shortcut
	When Paste the text 3 time using Ctrl+V shortcut
	Then close the notepad without saving it
