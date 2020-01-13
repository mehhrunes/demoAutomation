using System.Linq;
using System.Net;
using DemoAPITests.ApiModels;
using DemoAPITests.ApiProxy;
using FluentAssertions;
using NUnit.Framework;

namespace DemoAPITests.APITests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class SampleApiTests
    {
        private readonly PostModel _postModel = new PostModel
        {
            UserId = 1,
            Body = "some kind of evidence",
            Title = "some kind of reason"
        };

        private readonly CommentModel _commentModel = new CommentModel
        {
            PostId = 3,
            Body = "no idea what to put here",
            Email = "overandout@email.com",
            Name = "who"
        };

        private readonly SamplePostApi _postApi = new SamplePostApi();
        private readonly SampleCommentApi _commentApi = new SampleCommentApi();

        [TestCase(5)]
        public void Post_GetPostById_ReturnsPostData(int postId)
        {
            var post = _postApi.GetPost(postId);
            post.Title.Should().Be("nesciunt quas odio");
            post.UserId.Should().Be(1);
            post.Body.Should().StartWith("repudiandae veniam");

            _postApi.GetResponse().StatusCode.Should().BeEquivalentTo(HttpStatusCode.OK);
        }

        [Test]
        public void Post_GetAllPost_ReturnsCorrectPostCount()
        {
            var posts = _postApi.GetAllPosts();
            posts.Count.Should().Be(100);

            posts.First().UserId.Should().Be(1);
        }
        
        [Test]
        public void Post_CreatePost_ReturnsPostData()
        {
            var createdPost = _postApi.CreatePost(_postModel);

            createdPost.UserId.Should().Be(_postModel.UserId);
            createdPost.Body.Should().Be(_postModel.Body);
            createdPost.Title.Should().Be(_postModel.Title);

            _postApi.GetResponse().StatusCode.Should().BeEquivalentTo(HttpStatusCode.Created);
        }

        [TestCase(1)]
        public void DeletePost(int postId)
        {
            _postApi.DeletePost(postId);
            _postApi.GetResponse().StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [TestCase(3)]
        public void Comment_GetCommentById_ReturnsCommentData(int commentId)
        {
            var comment = _commentApi.GetComment(commentId);
            comment.Name.Should().Be("odio adipisci rerum aut animi");

            _commentApi.GetResponse().StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void Comment_CreateComment_ReturnsCommentData()
        {
            var createdComment = _commentApi.CreateComment(_commentModel);

            createdComment.PostId.Should().Be(_commentModel.PostId);
            createdComment.Body.Should().Be(_commentModel.Body);
            createdComment.Email.Should().Be(_commentModel.Email);
            createdComment.Name.Should().Be(_commentModel.Name);

            _commentApi.GetResponse().StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}