using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Core.Tests.Fixtures;
using Torito.Core.Tests.Fixtures.Json;
using Torito.Data.Persistance.DataModels;
using Torito.Models.Twitter;
using Xunit;

namespace Torito.Core.Torito.Core.Tests
{
    public class AddressCleanServiceTests : IClassFixture<ToritoCoreTestsFixture>
    {
        private ToritoCoreTestsFixture _fixture;
        public AddressCleanServiceTests(ToritoCoreTestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Should_Not_Be_Empty_Or_Null_String()
        {

            Assert.All(ConstantsTestData.AddressTweets, x =>
            {
                var tweet = new TweetDbo { Text = x.Item1.Replace("\r", "") };
                _fixture.AddressCleanService.SetAddressFromTweet(tweet);

                Assert.NotNull(tweet.AddressText);
                Assert.False(string.IsNullOrEmpty(tweet.AddressText));
            });
        }
        [Fact]
        public void Should_Get_Address_String()
        {
            
            Assert.All(ConstantsTestData.AddressTweets, x =>
            {
                var tweet = new TweetDbo { Text = x.Item1.Replace("\r", "") };
                _fixture.AddressCleanService.SetAddressFromTweet(tweet);

                Assert.Equal(x.Item2, tweet.AddressText);
            });
        }
    }
}
