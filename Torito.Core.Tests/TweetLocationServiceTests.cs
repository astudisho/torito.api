using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Torito.Core.Tests.Fixtures;
using Torito.Core.Tests.Fixtures.Json;
using Torito.Data.Persistance.DataModels;
using Xunit;

namespace Torito.Core.Tests
{
    public class TweetLocationServiceTests : IClassFixture<ToritoCoreTestsFixture>
    {
        private readonly ToritoCoreTestsFixture _fixture;
        public TweetLocationServiceTests(ToritoCoreTestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        async Task Should_Assign_Address_Text_To_Tweets()
        {
            var tweets = GetTweetsWithoutAddressText();

            Assert.All(await tweets, x => 
            {
                Assert.False(string.IsNullOrEmpty(x.AddressText));
            });
        }

        [Fact]
        async Task Should_Get_GeoLocation_Objects()
        {
            // var cancellationToken = new CancellationTokenSource(10000).Token;
            var cancellationToken = default(CancellationToken);
            var tweets = await GetTweetsWithoutAddressText(cancellationToken);

            var tweetsWithoutGeoLocation = await _fixture.TweetDbRepository.GetTweetsWithNullGeoLocation(cancellationToken);

            var resultTaskList = tweetsWithoutGeoLocation.Select(x => _fixture.LocationService.AssignAddressObjectToTweet(x, cancellationToken))
                .ToList();

            await Task.WhenAll(resultTaskList);

            var result = resultTaskList.Select(x => x.Result);

            Assert.All(result, x => 
            {
                Assert.NotNull(x.Geocode);
                Assert.NotNull(x.Geocode.Results);
                Assert.NotEmpty(x.Geocode.Results);
            });

            var aux = await _fixture.LocationService.AssignAddressObjectToTweet(tweets.First());
        }

        [Fact]
        async Task Should_Save_Tweet_With_Geolocation_In_Database()
        {

        }

        private async Task<IList<TweetDbo>> GetTweetsWithoutAddressText(CancellationToken cancellationToken = default)
        {
            var tweets = await _fixture.LocationService.AssignAddressTextToTweet(cancellationToken);

            return tweets;
        }
    }
}
