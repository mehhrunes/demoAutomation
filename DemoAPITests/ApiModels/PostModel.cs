using Bogus;

namespace DemoAPITests.ApiModels
{
    public class PostModel
    {
        public int UserId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public static PostModel GenerateModel()
        {
            return new Faker<PostModel>()
                .RuleFor(p => p.UserId, f => f.Random.Number(1, 110))
                .RuleFor(p => p.Title, f => f.Lorem.Sentence())
                .RuleFor(p => p.Body, f => f.Lorem.Paragraph())
                .Generate();
        }

        public override string ToString() => $"UserId:{UserId}\n Title:{Title}\n Body:{Body}";
    }
}