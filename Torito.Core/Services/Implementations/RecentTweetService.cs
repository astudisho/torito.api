using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Torito.Core.Services.Interfaces;
using Torito.Data.Interfaces;
using Torito.Models.Dtos;

namespace Torito.Core.Services.Implementations
{
    public class RecentTweetService : IRecentTweetService
    {
        private readonly ITweetDbRepository _tweetRepository;
        private readonly ILogger<RecentTweetService> _logger;
        private readonly IMapper _mapper;

        public RecentTweetService(ITweetDbRepository tweetDbRepository, IMapper mapper, ILogger<RecentTweetService> logger)
        {
            _tweetRepository = tweetDbRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IList<ToritoDto>> GetRecentTorito(CancellationToken ct = default)
        {
            var tweetTasks = _tweetRepository.GetRecent100TweetsWithGeoLocation(ct);

            var dbTweeets = await tweetTasks;

            var orderedTweets = dbTweeets.OrderByDescending(x => x.CreatedAt).ToList();

            var result = _mapper.Map<IList<ToritoDto>>(orderedTweets);

            return result;
        }

        public async Task<IList<ToritoDto>> GetLastDayTorito(CancellationToken ct = default)
        {
            var tweetTasks = _tweetRepository.GetLast24HrsWithGeoLocation(ct);

            var dbTweeets = await tweetTasks;

            var orderedTweets = dbTweeets.OrderByDescending(x => x.CreatedAt).ToList();

            var result = _mapper.Map<IList<ToritoDto>>(orderedTweets);

            return result;
        }
    }
}
