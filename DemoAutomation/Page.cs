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
        protected readonly IWebDriver driver;
        private WebDriverWait wait;
        private IJavaScriptExecutor javaScriptExecutor;
        private Actions actions;

        protected Page()
        {
            driver = DriverManager.GetInstance().Driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            javaScriptExecutor = driver as IJavaScriptExecutor;
            actions = new Actions(driver);
        }

        protected void WaitForElementToBeVisible(IWebElement element) => wait.Until(ExpectedConditions.ElementToBeClickable(element));

        protected void WaitForElementToBeVisible(By locator) => wait.Until(ExpectedConditions.ElementToBeClickable(locator));

        protected void SwitchToFrame(IWebElement frame) => driver.SwitchTo().Frame(frame);
        
        protected void SwitchToDefaultContent()
        {
            driver.SwitchTo().DefaultContent();
        }
    }
}