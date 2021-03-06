﻿using System;
using RestSharp;

namespace DemoAPITests.ApiProxy
{
    public class SampleApi
    {
        private readonly string BaseUrl = ApiConfig.CurrentApiConfig.BaseUrl;

        private readonly IRestClient _client;

        protected IRestResponse Response;

        protected SampleApi()
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
                throw new Exception("Sorry, I have no idea what happened.");
            }

            return response.Data;
        }
    }
}