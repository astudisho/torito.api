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
using static Torito.Models.Twitter.Enums.RecentSearchEnums;

namespace TwitterClient.Tests
{
    public class RecentSearchClientServiceTests
    {
        private readonly UserSecretManager _userSecretManager;
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
                Expansions = new List<Expansions> { Expansions.AuthorId }
            };
            var response = await _recentSearchService.GetRecentSearchAsync(query, recentSearchRequestParameters);


        }
    }
}
