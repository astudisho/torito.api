using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Data.Interfaces;
using Torito.Models.Twitter;
using TwitterClient.Interfaces;
using TwitterClient.Utils;
using static Torito.Models.Utils.Constants.Twitter.QueryParameters.RecentSearch;

namespace Torito.Data.Implementation
{
    public class TweetClientRepository : ITweetRepository
    {        
        private readonly IRecentSearchService _recentSearchService;
        public TweetClientRepository(IRecentSearchService recentSearchService)
        {
            _recentSearchService = recentSearchService;
        }

        public async Task<IList<Tweet>> GetLast100ToritoTweets()
        {
            var toritoQUery = Constants.Twitter.ToritoQuery;

            var request = new RecentSearchRequestParameters
            {
                MaxResults = 100,
                Expansions = new List<string> { Expansions.AuthorId, Expansions.GeoPlaceId },
                TweetFields = new List<string>
                {
                    TweetFields.AuthorId, TweetFields.CreatedAt, TweetFields.Text, TweetFields.Id, TweetFields.Geo, TweetFields.ContextAnnotations,
                    TweetFields.Entities
                }
                
            };

            var response = await _recentSearchService.GetRecentSearchAsync(toritoQUery, request);

            var result = response.Data.ToList();

            return result;
        }
    }
}
