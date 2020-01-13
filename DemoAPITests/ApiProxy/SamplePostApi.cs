using System.Collections.Generic;
using DemoAPITests.ApiModels;
using RestSharp;

namespace DemoAPITests.ApiProxy
{
    public class SamplePostApi : SampleApi
    {
        public PostModel GetPost(int postId)
        {
            var request = new RestRequest($"/posts/{postId}");
            return Execute<PostModel>(request, out Response);
        }

        public List<PostModel> GetAllPosts()
        {
            var request = new RestRequest("/posts");
            return Execute<List<PostModel>>(request, out Response);
        }

        public PostModel CreatePost(PostModel post)
        {
            var request = new RestRequest("posts/", Method.POST);

            request.AddParameter("userId", post.UserId);
            request.AddParameter("title", post.Title);
            request.AddParameter("body", post.Body);

            return Execute<PostModel>(request, out Response);
        }

        public void DeletePost(int postId)
        {
            var request = new RestRequest($"posts/{postId}", Method.DELETE);
            Execute<PostModel>(request, out Response);
        }
    }
}