using System;
using DemoAutomation.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DemoAutomation
{
    public class Page
    {
        protected readonly IWebDriver Driver;
        private readonly WebDriverWait _wait;
        private IJavaScriptExecutor _javaScriptExecutor;
        private Actions _actions;

        protected Page()
        {
            Driver = DriverManager.GetInstance().Driver;
            _wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            _javaScriptExecutor = Driver as IJavaScriptExecutor;
            _actions = new Actions(Driver);
        }

        protected void WaitForElementToBeVisible(IWebElement element) => _wait.Until(ExpectedConditions.ElementToBeClickable(element));

        protected void WaitForElementToBeVisible(By locator) => _wait.Until(ExpectedConditions.ElementToBeClickable(locator));

        protected void SwitchToFrame(IWebElement frame) => Driver.SwitchTo().Frame(frame);
        
        protected void SwitchToDefaultContent()
        {
            Driver.SwitchTo().DefaultContent();
        }
    }
}