using System;
using DemoAutomation.Steps;
using DemoAutomation.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using Serilog;

namespace DemoAutomation
{
    public class UITestFixture
    {
        private IWebDriver driver;
        private Config config = Config.CurrentConfig;

        [OneTimeSetUp]
        [LogMethod]
        public void FixtureSetUp()
        {
            driver = DriverManager.GetInstance().Driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            driver.Url = config.BaseUrl;

            AdminSteps.LogInAsAdmin();
        }

        [OneTimeTearDown]
        [LogMethod]
        public void FixtureTearDown()
        {
            driver.Quit();
        }

        public void Arrange(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch (Exception e)
            {
                Log.Debug($"Exception has been thrown during test arrangement. \n {e.Message}: {e.StackTrace}");
            }
        }

        public void CleanUp(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch (Exception e)
            {
                Log.Debug($"Exception has been thrown while performing a clean up. \n {e.Message}: {e.StackTrace}");
            }
        }
    }
}