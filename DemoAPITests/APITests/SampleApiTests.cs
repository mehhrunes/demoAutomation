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
        private readonly PostModel postModel = new PostModel
        {
            UserId = 1,
            Body = "some kind of evidence",
            Title = "some kind of reason"
        };

        private readonly CommentModel commentModel = new CommentModel
        {
            PostId = 3,
            Body = "no idea what to put here",
            Email = "overandout@email.com",
            Name = "who"
        };

        private readonly SamplePostApi postApi = new SamplePostApi();
        private readonly SampleCommentApi commentApi = new SampleCommentApi();

        [TestCase(5)]
        public void Post_GetPostById_ReturnsPostData(int postId)
        {
            var post = postApi.GetPost(postId);
            post.Title.Should().Be("nesciunt quas odio");
            post.UserId.Should().Be(1);
            post.Body.Should().StartWith("repudiandae veniam");

            postApi.GetResponse().StatusCode.Should().BeEquivalentTo(HttpStatusCode.OK);
        }

        [Test]
        public void Post_GetAllPost_ReturnsCorrectPostCount()
        {
            var posts = postApi.GetAllPosts();
            posts.Count.Should().Be(100);

            posts.First().UserId.Should().Be(1);
        }
        
        [Test]
        public void Post_CreatePost_ReturnsPostData()
        {
            var createdPost = postApi.CreatePost(postModel);

            createdPost.UserId.Should().Be(postModel.UserId);
            createdPost.Body.Should().Be(postModel.Body);
            createdPost.Title.Should().Be(postModel.Title);

            postApi.GetResponse().StatusCode.Should().BeEquivalentTo(HttpStatusCode.Created);
        }

        [TestCase(1)]
        public void DeletePost(int postId)
        {
            postApi.DeletePost(postId);
            postApi.GetResponse().StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [TestCase(3)]
        public void Comment_GetCommentById_ReturnsCommentData(int commentId)
        {
            var comment = commentApi.GetComment(commentId);
            comment.Name.Should().Be("odio adipisci rerum aut animi");

            commentApi.GetResponse().StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void Comment_CreateComment_ReturnsCommentData()
        {
            var createdComment = commentApi.CreateComment(commentModel);

            createdComment.PostId.Should().Be(commentModel.PostId);
            createdComment.Body.Should().Be(commentModel.Body);
            createdComment.Email.Should().Be(commentModel.Email);
            createdComment.Name.Should().Be(commentModel.Name);

            commentApi.GetResponse().StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}