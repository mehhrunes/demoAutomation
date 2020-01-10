using System;
using Bogus;

namespace DemoAutomation.Models.Cars
{
    public class CarModel
    {
        public string CarName { get; set; }
        
        public string CarDescription { get; set; }

        public MainCarSetting Setting { get; set; }

        public static CarModel GetBasicCar()
        {
            return new Faker<CarModel>()
                .RuleFor(c => c.CarName, f => f.Vehicle.Model())
                .RuleFor(c => c.CarDescription, f => f.Lorem.Paragraph())
                .Generate();
        }

        public static CarModel GetCarWithSettings()
        {
            var car = GetBasicCar();
            car.Setting = MainCarSetting.GetRandomMainSettings();
            return car;
        }

        public class MainCarSetting
        {
            public Status CarStatus { get; set; }

            public CarType CarType { get; set; }

            public YesNo IsFeatured { get; set; }

            public DateTime FeaturedFrom { get; set; }

            public DateTime FeaturedTo { get; set; }

            public DepositType DepositType { get; set; }
            
            public int DepositAmount { get; set; }

            public DepositType VatType { get; set; }
            
            public int VatAmount { get; set; }
            
            public int Stars { get; set; }

            public int Passengers { get; set; }

            public int Doors { get; set; }

            public TransmissionType Transmission { get; set; }

            public string Baggage { get; set; }

            public YesNo AirportPickUp { get; set; }

            public static MainCarSetting GetRandomMainSettings()
            {
                return new Faker<MainCarSetting>()
                    .RuleFor(s => s.CarStatus, f => f.PickRandom<Status>())
                    .RuleFor(s => s.CarType, f => f.PickRandom<CarType>())
                    .RuleFor(s => s.IsFeatured, f => f.PickRandom<YesNo>())
                    .RuleFor(s => s.FeaturedFrom, f => f.Date.Past(20, DateTime.Today))
                    .RuleFor(s => s.FeaturedTo, f => f.Date.Future(5, DateTime.Today))
                    .RuleFor(s => s.DepositType, f => f.PickRandom<DepositType>())
                    .RuleFor(s => s.DepositAmount, f => f.Random.Number(10, 100))
                    .RuleFor(s => s.VatType, f => f.PickRandom<DepositType>())
                    .RuleFor(s => s.VatAmount, f => f.Random.Number(10, 100))
                    .RuleFor(s => s.Stars, f => f.Random.Number(0, 5))
                    .RuleFor(s => s.Passengers, f => f.Random.Number(4, 6))
                    .RuleFor(s => s.Doors, f => f.Random.Number(2, 5))
                    .RuleFor(s => s.Transmission, f => f.PickRandom<TransmissionType>())
                    .RuleFor(s => s.Baggage, f => $"x{f.Random.Number(1, 6)}")
                    .RuleFor(s => s.AirportPickUp, f => f.PickRandom<YesNo>())
                    .Generate();
            }
        }
    }
}