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
using Torito.Models.Twitter;
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
        private readonly Task<IList<Tweet>> _cached100TweetTask;
        public CachedTweetsRepositoryTests(TweetRepositoryFixture fixture)
        {
            _tweetDbRepository = fixture.tweetDbRepository;
            _tweetClientRepository = fixture.tweetClientRepository;
            _cachedTweetService = fixture.cachedtweetService;
            _mapper = fixture.mapper;
            _cached100TweetTask = fixture.cachedLast100TweetsTask;
        }
        [Fact]
        public async Task CachedTweetsService_Should_Return_Tweets()
        {
            var result = await _cached100TweetTask;

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task Should_Return_Valid_Tweets()
        {
            var result = await _cached100TweetTask;

            var firstTweet = result.First();

            Assert.All(result, x =>
            {
                Assert.NotEqual(default, x.Id);
                Assert.NotEqual(default, x.CreatedAt);
                Assert.False(string.IsNullOrEmpty(x.Text));
                Assert.False(string.IsNullOrEmpty(x.AuthorId));
            });
        }

        [Fact]
        public async Task Should_Return_Valid_Entities()
        {
            var result = await _cached100TweetTask;

            Assert.All(result, x =>
            {
                var entities = x.Entities;
                Assert.NotEmpty(entities.Hashtags);
                if(entities?.Annotations is not null)
                {
                    Assert.NotEmpty(entities.Annotations);
                }
            });
        }

        [Fact]
        public async Task Should_Return_Valid_Annotations()
        {
            var result = await _cached100TweetTask;

            Assert.All(result, x =>
            {
                var annotations = x.Entities?.Annotations;

                if(annotations is not null)
                {
                    Assert.All(annotations, y =>
                    {
                        Assert.False(string.IsNullOrEmpty(y.NormalizedText));
                        Assert.NotEqual(default, y.Probability);
                    });
                }
            });
        }

        [Fact]
        public async Task Should_Return_Valid_Hashtags()
        {
            var result = await _cached100TweetTask;

            Assert.All(result, x =>
            {
                var hashtags = x.Entities.Hashtags;

                Assert.All(hashtags, y =>
                {
                    Assert.False(string.IsNullOrEmpty(y.Tag));
                });
            });
        }
    }
}
