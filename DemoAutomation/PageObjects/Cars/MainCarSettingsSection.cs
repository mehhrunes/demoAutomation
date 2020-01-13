using DemoAutomation.Models.Cars;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoAutomation.PageObjects.Cars
{
    public class MainCarSettingsSection : Page
    {
        private IWebElement CarStatusSelect => Driver.FindElement(By.Name("carstatus"));

        private IWebElement CarTypeDropDown => Driver.FindElement(By.Id("s2id_autogen21"));

        private IWebElement IsFeaturedSelect => Driver.FindElement(By.Id("isfeatured"));

        private IWebElement FeaturedFromDateField => Driver.FindElement(By.Name("ffrom"));

        private IWebElement FeaturedToDateField => Driver.FindElement(By.Name("fto"));

        private IWebElement DepositSelect => Driver.FindElement(By.Name("deposittype"));

        private IWebElement DepositAmountField => Driver.FindElement(By.Name("depositvalue"));

        private IWebElement VatTaxSelect => Driver.FindElement(By.Name("taxtype"));

        private IWebElement VatAmountField => Driver.FindElement(By.Name("taxvalue"));

        private IWebElement StarsSelect => Driver.FindElement(By.Name("carstars"));

        private IWebElement PassengersSelect => Driver.FindElement(By.Name("passangers"));

        private IWebElement CarDoorsSelect => Driver.FindElement(By.Name("doors"));

        private IWebElement TransmissionSelect => Driver.FindElement(By.Name("transmission"));

        private IWebElement BaggageSelect => Driver.FindElement(By.Name("baggage"));

        private IWebElement AirportPickUpSelect => Driver.FindElement(By.Name("airportpickup"));

        public CarCreationPage SelectCarStatus(CarModel car)
        {
            var statusSelect = new SelectElement(CarStatusSelect);
            statusSelect.SelectByText(car.Setting.CarStatus.ToString());
            return new CarCreationPage();
        }

        public CarCreationPage SelectCarType(CarModel car)
        {
            CarTypeDropDown.Click();
            WaitForElementToBeVisible(By.ClassName("select2-drop-active"));
            var input = Driver.FindElement(By.XPath("//div[contains(@class, 'select2-drop-active')]//input"));
            input.SendKeys(car.Setting.CarType.ToString());
            input.SendKeys(Keys.Enter);
            return new CarCreationPage();
        }

        public CarCreationPage SelectIsFeatured(CarModel car)
        {
            var isFeaturedSelect = new SelectElement(IsFeaturedSelect);
            isFeaturedSelect.SelectByText(car.Setting.IsFeatured.ToString());
            return new CarCreationPage();
        }

        public CarCreationPage SetFeaturedFrom(CarModel car)
        {
            FeaturedFromDateField.SendKeys(car.Setting.FeaturedFrom.ToShortDateString());
            return new CarCreationPage();
        }

        public CarCreationPage SetFeaturedTo(CarModel car)
        {
            FeaturedToDateField.SendKeys(car.Setting.FeaturedTo.ToShortDateString());
            //Click to hide the date pickers
            FeaturedToDateField.Click();
            return new CarCreationPage();
        }

        public CarCreationPage SelectDepositType(CarModel car)
        {
            var depositSelect = new SelectElement(DepositSelect);
            depositSelect.SelectByText(car.Setting.DepositType.ToString());
            return new CarCreationPage();
        }

        public CarCreationPage SetDepositAmount(CarModel car)
        {
            DepositAmountField.SendKeys(car.Setting.DepositAmount.ToString());
            return new CarCreationPage();
        }

        public CarCreationPage SelectVatType(CarModel car)
        {
            var vatSelect = new SelectElement(VatTaxSelect);
            vatSelect.SelectByText(car.Setting.VatType.ToString());
            return new CarCreationPage();
        }

        public CarCreationPage SetVatAmount(CarModel car)
        {
            VatAmountField.SendKeys(car.Setting.VatAmount.ToString());
            return new CarCreationPage();
        }

        public CarCreationPage SelectStars(CarModel car)
        {
            var starsSelect = new SelectElement(StarsSelect);
            starsSelect.SelectByValue(car.Setting.Stars.ToString());
            return new CarCreationPage();
        }

        public CarCreationPage SelectPassengers(CarModel car)
        {
            var passengersSelect = new SelectElement(PassengersSelect);
            passengersSelect.SelectByValue(car.Setting.Passengers.ToString());
            return new CarCreationPage();
        }

        public CarCreationPage SelectCarDoors(CarModel car)
        {
            var carDoorsSelect = new SelectElement(CarDoorsSelect);
            carDoorsSelect.SelectByValue(car.Setting.Doors.ToString());
            return new CarCreationPage();
        }

        public CarCreationPage SelectTransmission(CarModel car)
        {
            var transmissionSelect = new SelectElement(TransmissionSelect);
            transmissionSelect.SelectByText(car.Setting.Transmission.ToString());
            return new CarCreationPage();
        }

        public CarCreationPage SelectBaggage(CarModel car)
        {
            var baggageSelect = new SelectElement(BaggageSelect);
            baggageSelect.SelectByValue(car.Setting.Baggage);
            return new CarCreationPage();
        }

        public CarCreationPage SelectAirportPickUp(CarModel car)
        {
            var airportPickUpSelect = new SelectElement(AirportPickUpSelect);
            airportPickUpSelect.SelectByText(car.Setting.AirportPickUp.ToString());
            return new CarCreationPage();
        }
    }
}