using System;
using DemoAutomation.Models;
using DemoAutomation.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace DemoAutomation
{
    public class Tests : UITestFixture
    {
        private readonly CarModel car = CarModel.GetRandomCar();
        
        [Test]
        public void Test1()
        {
            new AdminConsole().OpenCars()
                .ClickAddCarButton()
                    .AddGeneralCarDetails(car);
        }
    }
}