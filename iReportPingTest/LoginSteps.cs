using iRePORT_PingTest.Common;
using iRePORT_PingTest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace iReportPingTest
{
    [Binding]
    public class LoginSteps
    {
        public static IWebDriver Driver = new ChromeDriver(ConfigurationSettings.AppSettings["chromeDriverPath"].ToString());
        public LoginPage loginPage = new LoginPage(Driver);

        [Given(@"I have navigated to the login screen")]
        public void GivenIHaveNavigatedToTheLoginScreen()
        {
            if (Driver.PageSource.Contains("Dashboard"))
            {
                Console.WriteLine("I am already logged in");
                return;
            }
            else
            {
                CommonMethods.GetURL();
                CommonMethods.CaptureScreenshot();
            }
        }
        
        [Given(@"I enter the username and password")]
        public void GivenIEnterTheUsernameAndPassword()
        {
            loginPage.EnterUsernamePassword(ConfigurationSettings.AppSettings["USER"].ToString(),
                    ConfigurationSettings.AppSettings["PASSWORD"].ToString());
            CommonMethods.CaptureScreenshot();
        }
        
        [When(@"I click Login button")]
        public void WhenIClickLoginButton()
        {
            loginPage.ClickLogin();
            CommonMethods.CaptureScreenshot();
        }
        
        [Then(@"I should see the dashboard")]
        public void ThenIShouldSeeTheDashboard()
        {
            System.Threading.Thread.Sleep(50000);

            NUnit.Framework.Assert.AreEqual(true, Driver.PageSource.Contains("Dashboard"));
            // Console.WriteLine("PASS");                

            CommonMethods.CaptureScreenshot();
            CommonMethods.cleanup();
        }
    }
}
