using Bogus;

namespace DemoAPITests.ApiModels
{
    public class CommentModel
    {
        public int PostId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Body { get; set; }

        public static CommentModel GenerateComment()
        {
            return new Faker<CommentModel>()
                .RuleFor(c => c.PostId, f => f.Random.Number(1, 100))
                .RuleFor(c => c.Name, f => f.Internet.UserName())
                .RuleFor(c => c.Email, f => f.Internet.Email())
                .RuleFor(c => c.Body, f => f.Rant.Review())
                .Generate();
        }

        public override string ToString() => $"PostId:{PostId}\n Name:{Name}\n Email:{Email}\n Body:{Body}";
    }
}