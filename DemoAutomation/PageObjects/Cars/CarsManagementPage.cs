using DemoAutomation.Models.Cars;
using OpenQA.Selenium;

namespace DemoAutomation.PageObjects.Cars
{
    public class CarsManagementPage : Page
    {
        private IWebElement AddCarButton => Driver.FindElement(By.XPath("//button[@type='submit']"));

        public CarCreationPage ClickAddCarButton()
        {
            AddCarButton.Click();
            return new CarCreationPage();
        }

        public string GetCarNameFromTable(CarModel car) => Driver.FindElement(By.XPath("//table/descendant::a[text()='" + car.CarName + "']")).Text;
    }
}