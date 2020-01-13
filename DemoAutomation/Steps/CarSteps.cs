using DemoAutomation.Models.Cars;
using DemoAutomation.PageObjects;

namespace DemoAutomation.Steps
{
    public static class CarSteps
    {
        public static string CreateCar(CarModel car)
        {
            return new AdminConsole().OpenCars()
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
        }
    }
}