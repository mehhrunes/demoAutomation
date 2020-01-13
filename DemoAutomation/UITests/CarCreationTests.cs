using DemoAutomation.Models.Cars;
using DemoAutomation.Steps;
using DemoAutomation.Utils;
using FluentAssertions;
using NUnit.Framework;

namespace DemoAutomation.UITests
{
    public class CarCreationTests : UITestFixture
    {
        private readonly CarModel _car = CarModel.GetCarWithSettings();

        [Test]
        [LogMethod]
        public void Cars_CreateCar_AddsCarToTheTable()
        {
            var newCar = CarSteps.CreateCar(_car);
            newCar.Should().Be(_car.CarName);
        }
    }
}