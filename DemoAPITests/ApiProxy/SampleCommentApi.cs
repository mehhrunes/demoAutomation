using System.Collections.Generic;
using DemoAPITests.ApiModels;
using RestSharp;

namespace DemoAPITests.ApiProxy
{
    public class SampleCommentApi : SampleApi
    {
        public CommentModel GetComment(int commentId)
        {
            var request = new RestRequest($"comments/{commentId}");
            return Execute<CommentModel>(request, out Response);
        }

        public List<CommentModel> GetAllComments()
        {
            var request = new RestRequest("comments/");
            return Execute<List<CommentModel>>(request, out Response);
        }

        public CommentModel CreateComment(CommentModel comment)
        {
            var request = new RestRequest("comments/", Method.POST);

            request.AddParameter("postId", comment.PostId);
            request.AddParameter("name", comment.Name);
            request.AddParameter("email", comment.Email);
            request.AddParameter("body", comment.Body);

            return Execute<CommentModel>(request, out Response);
        }
    }
}