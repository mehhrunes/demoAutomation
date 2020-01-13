﻿using System;
using DemoAutomation.Steps;
using DemoAutomation.Utils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Serilog;

namespace DemoAutomation
{
    public class UITestFixture
    {
        private IWebDriver driver;
        
        [OneTimeSetUp]
        [LogMethod]
        public void FixtureSetUp()
        {
            driver = DriverManager.GetInstance().Driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            driver.Url = Config.CurrentConfig.BaseUrl;

            AdminSteps.LogInAsAdmin();
        }

        [TearDown]
        [LogMethod]
        public void TestTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
                Log.Error($"{TestContext.CurrentContext.Test.Name} has failed: {TestContext.CurrentContext.Result.Message}");
            }
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