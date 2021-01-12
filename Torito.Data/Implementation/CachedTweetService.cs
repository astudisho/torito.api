using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Data.Interfaces;
using Torito.Models.Twitter;
using AutoMapper;
using Torito.Data.Persistance.DataModels;
using Torito.Models.Utils.Comparers;
using System.Threading;

namespace Torito.Data.Implementation
{
    public class CachedTweetService : ICachedTweetService
    {
        private readonly ITweetDbRepository _tweetDbRepository;
        private readonly ITweetRepository _tweetClientRepository;
        private readonly IMapper _mapper;
        public CachedTweetService(ITweetRepository tweetRepository, ITweetDbRepository tweetDbRepository, IMapper mapper)
        {
            _tweetClientRepository = tweetRepository;
            _tweetDbRepository = tweetDbRepository;
            _mapper = mapper;
        }
        public async Task<IList<Tweet>> FetchAndUpdateLast100Tweets()
        {
            // Create tasks.
            var dbTweetsTask = _tweetDbRepository.GetLast100ToritoTweets();
            var clientTweetsTask = _tweetClientRepository.GetLast100ToritoTweets();

            // Results.
            var dbtweetsResult = await dbTweetsTask;
            var dboTweets = _mapper.Map<IList<Tweet>>(dbtweetsResult);
            var clientTweetsResult = await clientTweetsTask;

            // Compare client results with Dbo.
            var toAddDbTweets = clientTweetsResult.Except(dboTweets, new TweetEqualityComparerById()).ToList();

            // Add not added tweets to DB.
            var toAddDbTweetsDbo = _mapper.Map<IList<TweetDbo>>(toAddDbTweets);
            await _tweetDbRepository.AddList(toAddDbTweetsDbo);

            return clientTweetsResult;
        }
    }
}
