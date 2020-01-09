using OpenQA.Selenium;

namespace DemoAutomation.PageObjects.Cars
{
    public class CarsManagementPage : Page
    {
        private IWebElement AddCarButton => driver.FindElement(By.XPath("//button[@type='submit']"));

        public CarCreationPage ClickAddCarButton()
        {
            AddCarButton.Click();
            return new CarCreationPage();
        }
    }
}