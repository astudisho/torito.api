using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public Task<RecentSearchResponse> GetRecentSearchAsync(string query, RecentSearchRequestParameters parameters, CancellationToken ct = default)
        {
            
            _restRequest = new RestRequest("/2/tweets/search/recent", DataFormat.Json);
            _restRequest.AddQueryParameter("query", query);

            AddQueryParameters(parameters);

            var response = _client.GetAsync<RecentSearchResponse>(_restRequest, ct);

            return response;
        }        
    }
}
