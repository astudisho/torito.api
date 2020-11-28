using System;
using System.Threading.Tasks;
using Xunit;

namespace TwitterClient.Tests
{
    public class TwtterBaseClientTests
    {
        [Fact]
        public async Task Test1()
        {
            var client = new TwitterBaseClient(Utils.Constants.GMaps.GMapsApiKey);

            var response = await client.GetRecentSearchAsync("from:damplin #toritojalisco");

            Assert.NotNull(response);
            Assert.NotEmpty(response.Data);
        }
    }
}
