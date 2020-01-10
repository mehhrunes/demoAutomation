using DemoAutomation.Models.Cars;
using DemoAutomation.PageObjects;
using DemoAutomation.Utils;
using FluentAssertions;
using NUnit.Framework;

namespace DemoAutomation.UITests
{
    public class CarCreationTests : UITestFixture
    {
        private readonly CarModel car = CarModel.GetCarWithSettings();
        
        [Test]
        [LogMethod]
        public void Cars_CreateCar_AddsCarToTheTable()
        {
            var newCar = new AdminConsole().OpenCars()
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
                    .ClickAddCarButton()
                .GetCarNameFromTable(car);

            newCar.Should().Be(car.CarName);
        }
    }
}