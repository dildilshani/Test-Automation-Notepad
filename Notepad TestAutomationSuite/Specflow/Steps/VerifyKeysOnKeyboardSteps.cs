using System;
using System.Threading;
using Notepad_TestAutomationSuite.Page_Objects;
using Notepad_TestAutomationSuite.Utility;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Notepad_TestAutomationSuite.Specflow.Steps
{
    [Binding]
    public class VerifyKeysOnKeyboardSteps
    {
        private readonly Excel _excel = new Excel();
        private readonly Notepad_Tool _notepad = new Notepad_Tool();

        [Given(@"I have typed something on text editor")]
        public void GivenIHaveTypedSomethingOnTextEditor()
        {
            try
            {
                _notepad.textEditor.SendKeys(_excel.readExcel(@"E:/Test dra 02.xlsx", 1, 3, 2));
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        
        [Given(@"select the text using Ctrl\+A keyboard shortcut")]
        public void GivenSelectTheTextUsingCtrlAKeyboardShortcut()
        {
            try
            {
                _notepad.textEditor.SendKeys(Keys.Control + _excel.readExcel(@"E:/Test dra 02.xlsx", 1, 4, 2) +
                                             Keys.Control); // Select all using Ctrl + A keyboard shortcut
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //[Given(@"copy the text using Ctrl\+C keybaord shortcut")]
        //public void GivenCopyTheTextUsingCtrlCKeybaordShortcut()
        //{
        //    try
        //    {
        //        _notepad.textEditor.SendKeys(Keys.Control + "c" +
        //                                     Keys.Control); // Copy using Ctrl + C keyboard shortcut
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}
        [Given(@"copy the text using Ctrl\+C keyboard shortcut")]
        public void GivenCopyTheTextUsingCtrlCKeyboardShortcut()
        {
            try
            {
                _notepad.textEditor.SendKeys(Keys.Control + "c" +
                                             Keys.Control); // Copy using Ctrl + C keyboard shortcut
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [When(@"Paste the text (.*) time using Ctrl\+V shortcut")]
        public void WhenPasteTheTextTimeUsingCtrlVShortcut(int p0)
        {
            try
            {
                _notepad.textEditor.SendKeys(Keys.Control + "vvv" +
                                             Keys.Control); // Paste 2 times using Ctrl + V keyboard shortcut
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [Then(@"close the notepad without saving it")]
        public void ThenCloseTheNotepadWithoutSavingIt()
        {
            Thread.Sleep(10);

            if (_notepad.close.Displayed)
            {
                _notepad.close.Click();

                if (_notepad.dontSave.Displayed)
                {
                    try
                    {
                        _notepad.saveKeyword.Click();

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    

                }
        

            }


        }
    }
}