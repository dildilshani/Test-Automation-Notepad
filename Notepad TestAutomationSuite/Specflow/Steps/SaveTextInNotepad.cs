using System;
using System.Threading;
using Notepad_TestAutomationSuite.Page_Objects;
using Notepad_TestAutomationSuite.Utility;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Notepad_TestAutomationSuite.Specflow.Steps
{
    [Binding]
    public class SaveTextInNotepad
    {
        private readonly Excel _excel = new Excel();
        private readonly Notepad_Tool _notepad = new Notepad_Tool();

        [Given(@"I have entered new content in opened notepad")]
        public void GivenIHaveEnteredNewContentInOpenedNotepad()
        {
            try
            {
                _notepad.textEditor.SendKeys(_excel.readExcel(@"E:/Test dra 02.xlsx", 1, 2, 2));
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [When(@"I save it")]
        public void WhenISaveIt()
        {
            try
            {
                _notepad.fileKeyword.Click();
                _notepad.saveAsKeyword.Click();

                Thread.Sleep(TimeSpan.FromSeconds(2));

                _notepad.searchEditBoxKeyword.Clear();
                _notepad.fileNameControlHostKeyword.SendKeys(_excel.readExcel(@"E:/Test dra 02.xlsx", 1, 1, 2));
                _notepad.saveKeyword.Click();

                var checkDialog = _notepad.confirmSaveAsKeyword;
                if (checkDialog.Displayed)
                {
                    
                    _notepad.yesKeyword.Click();
                }
                else
                {
                    _notepad.noKeyword.Click();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [Then(@"the Notepad must save in the default location")]
        public void ThenTheNotepadMustSaveInTheDefaultLocation()
        {
            try
            {
                var actualName = _excel.readExcel(@"E:/Test dra 02.xlsx", 1, 1, 2).ToString();
                Console.WriteLine(actualName);
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}