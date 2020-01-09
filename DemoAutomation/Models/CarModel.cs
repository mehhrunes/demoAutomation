using Bogus;

namespace DemoAutomation.Models
{
    public class CarModel
    {
        public string CarName { get; set; }
        
        public string CarDescription { get; set; }

        public static CarModel GetRandomCar()
        {
            return new Faker<CarModel>()
                .RuleFor(c => c.CarName, f => f.Vehicle.Model())
                .RuleFor(c => c.CarDescription, f => f.Lorem.Paragraph())
                .Generate();
        }
    }
}