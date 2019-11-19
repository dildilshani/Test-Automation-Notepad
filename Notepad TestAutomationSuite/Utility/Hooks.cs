using System;
using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using TechTalk.SpecFlow;

namespace Notepad_TestAutomationSuite.Utility
{
    [Binding]
    public class Hooks
    {
      
        static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        public static ExtentReports extRptDrv;
        public static WindowsDriver<WindowsElement> driver;

        [BeforeTestRun]
        public static void InitializeReport()
        {
            //Initialize Extent report before test starts
            var htmlReporter = new ExtentHtmlReporter(@"E:/Notepad Test/Notepad TestAutomationSuite/Notepad TestAutomationSuite/Reports");
            htmlReporter.Config.Theme = Theme.Dark;

            //Attach report to reporter
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            //Create dynamic feature name
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeScenario]
        private static WindowsDriver<WindowsElement> Initialize()
        {
            //var appCapabilities = new OpenQA.Selenium.Remote.DesiredCapabilities();
            //appCapabilities.SetCapability("app", @"C:/Windows/System32/notepad.exe");



            AppiumOptions opt = new AppiumOptions();
            opt.AddAdditionalCapability("app", @"C:/Windows/System32/notepad.exe");
            opt.AddAdditionalCapability("device", "WindowsPC");

            driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), opt);

            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
            Assert.AreEqual("Untitled - Notepad", driver.Title);

            return driver;
        } 

      //  [AfterStep]
        public void InsertReportingSteps()
        {

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            }

            if (ScenarioContext.Current.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
            }

        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            //Flush report once test completes
            extent.Flush();
        }

    //    [AfterScenario]
        public static void CleanUp()
        {
    //        driver.Quit(); //  driver is defined as public static WindowsDriver<WindowsElement> driver;
        }
    }
}
