using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Data.Implementation;
using Torito.Data.Interfaces;
using Torito.Data.Persistance.Context;
using Torito.Data.Tests.Fixtures;
using Torito.Models.Utils.Tools;
using Xunit;

namespace Torito.Data.Tests
{
    public class CachedTweetsRepositoryTests : IClassFixture<TweetRepositoryFixture>
    {
        private readonly ITweetDbRepository _tweetDbRepository;
        private readonly ITweetRepository _tweetClientRepository;
        private readonly ICachedTweetService _cachedTweetService;
        private readonly IMapper _mapper;
        public CachedTweetsRepositoryTests(TweetRepositoryFixture fixture)
        {
            _tweetDbRepository = fixture.tweetDbRepository;
            _tweetClientRepository = fixture.tweetClientRepository;
            _cachedTweetService = fixture.cachedtweetService;
            _mapper = fixture.mapper;
        }
        [Fact]
        public async Task CachedTweetsService_Should_Return_Tweets()
        {
            var result = await _cachedTweetService.GetLast100Tweets();
        }
    }
}
