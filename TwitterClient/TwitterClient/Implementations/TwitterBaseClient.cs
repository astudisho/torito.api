using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Threading.Tasks;
using Torito.Models.Twitter;

namespace TwitterClient
{
    public class TwitterBaseClient
    {
        private RestClient _client;
        private string _baseUrl => "https://api.twitter.com/";

        public TwitterBaseClient(string apiKey)
        {
            _client = new RestClient(_baseUrl);

            _client.AddDefaultHeader("Authorization", $"Bearer {apiKey}");
        }

        public async Task<RecentSearchResponse> GetRecentSearchAsync(string query)
        {
            var request = new RestRequest("/2/tweets/search/recent", DataFormat.Json);
            request.AddQueryParameter("query", query);
            var response = await _client.GetAsync<RecentSearchResponse>(request);

            return response;
        }
    }
}
