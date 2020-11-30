using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Models.Twitter;
using TwitterClient.Implementations;
using TwitterClient.Interfaces;
using TwitterClient.Tests.Utils;
using Xunit;
using static Torito.Models.Utils.Constants.Twitter.QueryParameters.RecentSearch;

namespace TwitterClient.Tests
{
    public class RecentSearchClientServiceTests
    {
        private readonly IRecentSearchService  _recentSearchService;

        public RecentSearchClientServiceTests()
        {
            var secretManager = new UserSecretManager();
            var apiKey = secretManager.GetTwitterApiKey();

            _recentSearchService = new RecentSearchService(apiKey);
        }

        [Fact]
        public async Task Should_Retrieve_Twits()
        {
            var query = "from:damplin #toritojalisco";
            var recentSearchRequestParameters = new RecentSearchRequestParameters
            {
                Expansions = new List<string> { Expansions.AuthorId, Expansions.GeoPlaceId },
                TweetFields = new List<string> 
                { 
                    TweetFields.AuthorId, TweetFields.CreatedAt, TweetFields.Text, TweetFields.Id, TweetFields.Geo, TweetFields.ContextAnnotations,
                    TweetFields.Entities
                }
            };
            var response = await _recentSearchService.GetRecentSearchAsync(query, recentSearchRequestParameters);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
            Assert.NotEqual(default(int), response.Meta.Count);
        }
    }
}
