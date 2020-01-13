﻿using System.Collections.Generic;
using DemoAPITests.ApiModels;
using RestSharp;

namespace DemoAPITests.ApiProxy
{
    public class SampleApi
    {
        private const string BaseUrl = "https://jsonplaceholder.typicode.com/";

        private readonly IRestClient _client;

        protected IRestResponse Response;

        public SampleApi()
        {
            _client = new RestClient(BaseUrl);
        }

        public IRestResponse GetResponse() => Response;

        protected T Execute<T>(RestRequest request, out IRestResponse responseData) where T : new()
        {
            var response = _client.Execute<T>(request);
            responseData = _client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                //exception handling
            }

            return response.Data;
        }

        // public PostModel GetPost(int postId)
        // {
        //     var request = new RestRequest($"/posts/{postId}");
        //     return Execute<PostModel>(request, out _response);
        // }
        //
        // public List<PostModel> GetAllPosts()
        // {
        //     var request = new RestRequest("/posts");
        //     return Execute<List<PostModel>>(request, out _response);
        // }
        //
        // public PostModel CreatePost(PostModel post)
        // {
        //     var request = new RestRequest("posts/", Method.POST);
        //
        //     request.AddParameter("userId", post.UserId);
        //     request.AddParameter("title", post.Title);
        //     request.AddParameter("body", post.Body);
        //
        //     return Execute<PostModel>(request, out _response);
        // }
        //
        // public void DeletePost(int postId)
        // {
        //     var request = new RestRequest($"posts/{postId}", Method.DELETE);
        //     Execute<PostModel>(request, out _response);
        // }

        // public CommentModel GetComment(int commentId)
        // {
        //     var request = new RestRequest($"comments/{commentId}");
        //     return Execute<CommentModel>(request, out Response);
        // }
        //
        // public List<CommentModel> GetAllComments()
        // {
        //     var request = new RestRequest("comments/");
        //     return Execute<List<CommentModel>>(request, out Response);
        // }
        //
        // public CommentModel CreateComment(CommentModel comment)
        // {
        //     var request = new RestRequest("comments/", Method.POST);
        //
        //     request.AddParameter("postId", comment.PostId);
        //     request.AddParameter("name", comment.Name);
        //     request.AddParameter("email", comment.Email);
        //     request.AddParameter("body", comment.Body);
        //
        //     return Execute<CommentModel>(request, out Response);
        // }
    }
}