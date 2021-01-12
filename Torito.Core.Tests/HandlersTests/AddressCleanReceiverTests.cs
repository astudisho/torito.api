using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Core.Tests.Fixtures;
using Torito.Core.Tests.Fixtures.Json;
using Torito.Data.Persistance.DataModels;
using Xunit;

namespace Torito.Core.Tests.HandlersTests
{
    public class AddressCleanReceiverTests : IClassFixture<Fixtures.ToritoCoreTestsFixture>
    {
        private readonly ToritoCoreTestsFixture _fixture;
        public AddressCleanReceiverTests(ToritoCoreTestsFixture fixture)
        {
            _fixture = fixture;
        }
        [Fact]
        public void Should_Clean_Address()
        {
            Assert.All(ConstantsTestData.AddressTweets, x =>
            {
                TweetDbo tweet = new() { Text = x.Item1 };

                _fixture.AddressCleanReceiver.Handle(tweet);

                Assert.Equal(x.Item2, tweet.AddressText);
            });            
        }
    }
}
