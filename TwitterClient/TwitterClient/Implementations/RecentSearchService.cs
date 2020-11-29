﻿using RestSharp;
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
            var request = new RestRequest("/2/tweets/search/recent", DataFormat.Json);
            request.AddQueryParameter("query", query);

            //AddQueryParameters(parameters);

            var response = await _client.GetAsync<RecentSearchResponse>(request);

            return response;
        }        
    }
}
