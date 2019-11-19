using System;
using Notepad_TestAutomationSuite.Page_Objects;
using Notepad_TestAutomationSuite.Utility;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Notepad_TestAutomationSuite
{
    [Binding]
    public class VerifyFormatTextsNotepadSteps
    {
        private readonly Excel _excel = new Excel();
        private readonly Notepad_Tool _notepad = new Notepad_Tool();

        [Given(@"I have entered text in text editor")]
        public void GivenIHaveEnteredTextInTextEditor()
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

        [Given(@"press Format button on menu")]
        public void GivenPressFormatButtonOnMenu()
        {
            try
            {
                _notepad.format.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [When(@"I change different formats")]
        public void WhenIChangeDifferentFormats()
        {
            try
            {
                _notepad.font.Click();
                _notepad.comicSansMsFont.Click();
                _notepad.italicStyle.Click();
                _notepad.okKeyword.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }



        [Then(@"text dispaly with relevant format and close notepad")]
        public void ThenTextDispalyWithRelevantFormatAndCloseNotepad()
        {


            if (_notepad.close.Displayed)
            {
                _notepad.close.Click();

         
               var checkDialog = Hooks.driver.FindElementById("TitleBar");
                checkDialog.SendKeys(Keys.Tab);
                if (checkDialog.Displayed)
                {

                    _notepad.dontSave.Click();
                }
                else
                {
                    Console.WriteLine("ttttttttttt");
                }
            }



        }
    }
}
