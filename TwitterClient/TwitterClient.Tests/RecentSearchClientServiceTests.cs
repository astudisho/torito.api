using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Models.Twitter;
using Torito.Models.Utils.Tools;
using TwitterClient.Implementations;
using TwitterClient.Interfaces;
using TwitterClient.Utils;
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
            var query = Constants.Twitter.ToritoQuery;
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

        [Fact]
        public async Task Should_Retrieve_Tweets_With_Valid_Properties()
        {
            var query = Constants.Twitter.ToritoQuery;
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

            Assert.All(response.Data, x => 
            {
                Assert.NotEqual(default, x.AuthorId);
                Assert.NotEmpty(x.Entities?.Annotations);
                Assert.NotEqual(default, x.Id);
                Assert.False(string.IsNullOrEmpty(x.Text));
            });
            Assert.NotEqual(default(int), response.Meta.Count);

        }
    }
}
