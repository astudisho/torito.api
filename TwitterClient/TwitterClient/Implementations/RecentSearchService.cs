using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Models.Twitter;
using TwitterClient.Interfaces;

namespace TwitterClient.Implementations
{
    public class RecentSearchService : TwitterBaseClient, IRecentSearchService
    {
        public RecentSearchService(string apiKey) : base(apiKey)
        {
            
        }

        public async Task<RecentSearchResponse> GetRecentSearchAsync(string query, RecentSearchRequestParameters parameters)
        {
            
            _restRequest = new RestRequest("/2/tweets/search/recent", DataFormat.Json);
            _restRequest.AddQueryParameter("query", query);

            AddQueryParameters(parameters);

            var response = await _client.GetAsync<RecentSearchResponse>(_restRequest);

            return response;
        }        
    }
}
