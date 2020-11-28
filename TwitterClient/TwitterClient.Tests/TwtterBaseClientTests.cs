using System;
using Xunit;

namespace TwitterClient.Tests
{
    public class TwtterBaseClientTests
    {
        [Fact]
        public void Test1()
        {
            var client = new TwitterBaseClient(Utils.Constants.GMaps.GMapsApiKey);

            var response = client.GetRecentSearch("from:damplin #toritojalisco");
        }
    }
}
