using System;
using System.Threading;
using Notepad_TestAutomationSuite.Page_Objects;
using Notepad_TestAutomationSuite.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.MultiTouch;
using TechTalk.SpecFlow;

namespace Notepad_TestAutomationSuite.Specflow.Steps
{
    [Binding]
    public class GetTimeDateAndSaveInNotepadSteps
    {
        private readonly Notepad_Tool _notepad = new Notepad_Tool();

        [Given(@"I have clicked Edit in Menu")]
        public void GivenIHaveClickedEditInMenu()
        {
            try
            {
                _notepad.textEditor.Click();
                _notepad.edit.Click();

             
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [When(@"the Edit menu is expanded")]
        public void WhenTheEditMenuIsExpanded()
        {
            try
            {
                Assert.AreEqual(true, _notepad.timeDate.Enabled);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }



        [When(@"Click Time/Date to see current Date and Time")]
        public void WhenClickTimeDateToSeeCurrentDateAndTime()
        {
            try
            {
                _notepad.timeDate.Click();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        [Then(@"Close the Notepad without saving it")]
        public void ThenCloseTheNotepadWithoutSavingIt()
        {
            try
            {

                _notepad.close.Click();
                Thread.Sleep(5000);
              //  _notepad.dontSave.Click();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }




        }
    }
}

        
