using DemoAutomation.Models.Cars;
using OpenQA.Selenium;

namespace DemoAutomation.PageObjects.Cars
{
    public class CarCreationPage : Page
    {
        private IWebElement CarNameField => Driver.FindElement(By.Name("carname"));

        private IWebElement CarDescriptionFrame =>
            Driver.FindElement(By.XPath("//iframe[contains(@title, 'Rich Text Editor')]"));

        private IWebElement CarDescriptionField => Driver.FindElement(By.TagName("p"));

        private IWebElement AddCarButton => Driver.FindElement(By.Id("add"));

        public MainCarSettingsSection MainSettings => new MainCarSettingsSection();

        public CarCreationPage AddGeneralCarDetails(CarModel car)
        {
            TypeCarName(car);
            TypeCarDescription(car);
            return this;
        }

        public CarsManagementPage ClickAddCarButton()
        {
            AddCarButton.Click();
            return new CarsManagementPage();
        }

        private void TypeCarName(CarModel car) => CarNameField.SendKeys(car.CarName);

        private void TypeCarDescription(CarModel car)
        {
            SwitchToFrame(CarDescriptionFrame);
            CarDescriptionField.SendKeys(car.CarDescription);
            SwitchToDefaultContent();
        }
    }
}