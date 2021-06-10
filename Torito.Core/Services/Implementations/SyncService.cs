using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Torito.Core.Services.Interfaces;
using Torito.Data.Interfaces;
using Torito.Data.Persistance.DataModels;
using Torito.Models.Twitter;
using Torito.Models.Utils.Comparers;

namespace Torito.Core.Services.Implementations
{
    public class SyncService : ISyncService
    {
        private readonly ITweetLocationService _tweetLocationService;
        private readonly ITweetRepository _tweetClientRepository;
        private readonly ICachedTweetService _cachedTweetService;
        private readonly ITweetDbRepository _tweetDbRepository;
        private readonly IAddressCleanService _addressCleanService;
        private readonly IMapper _mapper;
        public SyncService(ITweetLocationService tweetLocationService
            , ITweetRepository tweetRepository
            , ICachedTweetService cachedTweetService
            , ITweetDbRepository tweetDbRepository
            , IAddressCleanService addressCleanService
            , IMapper mapper)
        {
            _tweetLocationService = tweetLocationService;
            _tweetClientRepository = tweetRepository;
            _cachedTweetService = cachedTweetService;
            _tweetDbRepository = tweetDbRepository;
            _addressCleanService = addressCleanService;
            _mapper = mapper;
        }

        public async Task<int> SyncTweets(CancellationToken ct = default)
        {

            // Create tasks.
            var dbTweetsTask = _tweetDbRepository.GetLast100ToritoTweets(ct);
            var clientTweetsTask = _tweetClientRepository.GetLast100ToritoTweets(ct);

            // Results.
            var dbtweetsResult = await dbTweetsTask;
            var dboTweets = _mapper.Map<IList<Tweet>>(dbtweetsResult);
            var clientTweetsResult = await clientTweetsTask;

            // Compare client results with Dbo.
            var toAddDbTweets = clientTweetsResult.Except(dboTweets, new TweetEqualityComparerById()).ToList();

            // Add not added tweets to DB.
            var toAddDbTweetsDbo = _mapper.Map<IList<TweetDbo>>(toAddDbTweets);
            await _tweetDbRepository.AddList(toAddDbTweetsDbo);

            return toAddDbTweets.Count();
            //return clientTweetsResult;
        }

        public async Task<int> SyncAddress(CancellationToken ct)
        {
            // Tasks.
            var dbTweetTask = _tweetDbRepository.GetTweetsWithNullAddressText(ct);

            // Results.
            var dbTweetsResult = await dbTweetTask;

            // Logic.
            foreach (TweetDbo dbtweet in dbTweetsResult)
            {
                _addressCleanService.SetAddressFromTweet(dbtweet);
            }

            // Save objects.
            await _tweetDbRepository.SaveAsync();

            return dbTweetsResult.Count();
        }

        public async Task<int> SyncLocation(CancellationToken ct)
        {
            // Tasks.
            var dbTweetsTask = _tweetDbRepository.GetTweetsWithNullGeoLocation(ct);

            // Results.
            var dbTweetsResults = await dbTweetsTask;

            var assignTweetLocationTasks = dbTweetsResults.Select(x => _tweetLocationService.AssignAddressObjectToTweet(x, ct));

            await Task.WhenAll(assignTweetLocationTasks);

            await _tweetDbRepository.SaveAsync();

            return assignTweetLocationTasks.Count();
        }
    }
}
