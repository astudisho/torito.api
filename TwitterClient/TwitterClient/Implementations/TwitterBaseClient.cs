using RestSharp;
using RestSharp.Authenticators;
using System;
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

        public RecentSearchResponse GetRecentSearch(string query)
        {
            var request = new RestRequest("/2/tweets/search/recent", DataFormat.Json);
            request.AddQueryParameter("query", query);
            var response = _client.Get<RecentSearchResponse>(request);

            if (response.IsSuccessful)
            {
                var aux = _client.Get(request);
                return response.Data;
            }

            throw new ApplicationException($"Status: {response.StatusCode} Description: {response.StatusDescription}");
        }
    }
}
