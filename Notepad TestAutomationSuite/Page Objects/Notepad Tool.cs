using Notepad_TestAutomationSuite.Utility;
using OpenQA.Selenium.Appium.Windows;

namespace Notepad_TestAutomationSuite.Page_Objects
{
    public class Notepad_Tool
    {
        public WindowsElement textEditor => Hooks.driver.FindElementByName("Text Editor");
        public WindowsElement fileKeyword => Hooks.driver.FindElementByName("File");
        public WindowsElement saveAsKeyword => Hooks.driver.FindElementByName("Save As...");
        public WindowsElement searchEditBoxKeyword => Hooks.driver.FindElementByAccessibilityId("SearchEditBox");
        public WindowsElement desktopKeyword => Hooks.driver.FindElementByName("Desktop (pinned)");
        public WindowsElement fileNameControlHostKeyword => Hooks.driver.FindElementByAccessibilityId("FileNameControlHost");
        public WindowsElement saveKeyword => Hooks.driver.FindElementByName("Save");
        public WindowsElement confirmSaveAsKeyword => Hooks.driver.FindElementByName("Confirm Save As");
        public WindowsElement yesKeyword => Hooks.driver.FindElementByName("Yes");
        public WindowsElement noKeyword => Hooks.driver.FindElementByName("No");
        public WindowsElement edit => Hooks.driver.FindElementByName("Edit");
        public WindowsElement timeDate => Hooks.driver.FindElementByXPath($"//MenuItem[starts-with(@Name, \"Time/Date\")]");
        public WindowsElement close => Hooks.driver.FindElementByName("Close");
        public WindowsElement notepad => Hooks.driver.FindElementByName("Notepad");
        public WindowsElement fileExplorer => Hooks.driver.FindElementByName("File Explorer");
        public WindowsElement format => Hooks.driver.FindElementByName("Format");
        public WindowsElement font => Hooks.driver.FindElementByName("Font...");
        public WindowsElement comicSansMsFont => Hooks.driver.FindElementByName("Comic Sans MS");
        public WindowsElement italicStyle => Hooks.driver.FindElementByName("Italic");
        public WindowsElement okKeyword => Hooks.driver.FindElementByName("OK");
        public WindowsElement dontSave => Hooks.driver.FindElementByName("Don't Save");
        public WindowsElement notepadTouch => Hooks.driver.FindElementByName("Notepad");
        public WindowsElement folderId => Hooks.driver.FindElementByName("2");
        public WindowsElement itemViewGrid => Hooks.driver.FindElementByName("Items View");
        public WindowsElement folder2Id => Hooks.driver.FindElementByName("2");
        public WindowsElement open => Hooks.driver.FindElementByName("Open");
        public WindowsElement folder3Id => Hooks.driver.FindElementByName("0");

    }
}

