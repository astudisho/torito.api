using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Torito.Core.Tests.Fixtures;
using Torito.Core.Tests.Fixtures.Json;
using Torito.Data.Persistance.DataModels;
using Xunit;

namespace Torito.Core.Tests.ReceiversTests
{
    public class RetweetCleanReceiverTests : IClassFixture<ToritoCoreTestsFixture>
    {
        private readonly ToritoCoreTestsFixture _fixture;

        public RetweetCleanReceiverTests(ToritoCoreTestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Shuold_Clean_Retweet()
        {
            Assert.All(ConstantsTestData.RetweetTweets, x =>
            {
                TweetDbo tweet = new() { AddressText = x.Item1 };
                _fixture.RetweetCleanReceiver.Handle(tweet);

                Assert.Equal(x.Item2, tweet.AddressText);
            });
        }
    }
}
