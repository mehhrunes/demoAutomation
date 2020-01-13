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
    }
}