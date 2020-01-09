using System.Threading;
using DemoAutomation.PageObjects.Cars;
using OpenQA.Selenium;

namespace DemoAutomation.PageObjects
{
    public class AdminConsole : Page
    {
        private IWebElement CarsExpandLink => driver.FindElement(By.XPath("//a[@href='#Cars' and @data-toggle='collapse']"));

        private IWebElement CarsLink => driver.FindElement(By.XPath("//ul[@id='Cars']//a[text()='Cars']"));

        public CarsManagementPage OpenCars()
        {
            ExpandCarsView();
            CarsLink.Click();
            return new CarsManagementPage();
        }
        
        private void ExpandCarsView()
        {
            WaitForElementToBeVisible(By.ClassName("imagelogo"));
            CarsExpandLink.Click();
        }
    }
}