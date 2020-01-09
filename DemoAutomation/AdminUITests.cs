using System;
using DemoAutomation.Models;
using DemoAutomation.PageObjects;
using DemoAutomation.Utils;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace DemoAutomation
{
    public class Tests : UITestFixture
    {
        private readonly CarModel car = CarModel.GetCarWithSettings();
        
        [Test]
        [LogMethod]
        public void Test1()
        {
            new AdminConsole().OpenCars()
                .ClickAddCarButton()
                    .AddGeneralCarDetails(car)
                    .MainSettings.SelectCarStatus(car)
                    .MainSettings.SelectCarType(car)
                    .MainSettings.SelectIsFeatured(car)
                    .MainSettings.SetFeaturedFrom(car)
                    .MainSettings.SetFeaturedTo(car)
                    .MainSettings.SelectDepositType(car)
                    .MainSettings.SetDepositAmount(car)
                    .MainSettings.SelectVatType(car)
                    .MainSettings.SetVatAmount(car)
                    .MainSettings.SelectStars(car)
                    .MainSettings.SelectPassengers(car)
                    .MainSettings.SelectCarDoors(car)
                    .MainSettings.SelectTransmission(car)
                    .MainSettings.SelectBaggage(car)
                    .MainSettings.SelectAirportPickUp(car)
                    .ClickAddCarButton();
        }
    }
}