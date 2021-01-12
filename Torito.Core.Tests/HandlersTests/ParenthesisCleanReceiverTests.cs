﻿using System;
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
    public class ParenthesisCleanReceiverTests : IClassFixture<ToritoCoreTestsFixture>
    {
        private readonly ToritoCoreTestsFixture _fixture;

        public ParenthesisCleanReceiverTests(ToritoCoreTestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Should_Clean_Parenthesis()
        {
            Assert.All(ConstantsTestData.ParenthesisTweets, x =>
            {
                TweetDbo tweet = new() { AddressText = x.Item1 };

                _fixture.ParenthesisCleanReceiver.Handle(tweet);

                Assert.Equal(x.Item2, tweet.AddressText);
            });
        }
    }
}
