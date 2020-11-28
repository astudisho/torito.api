using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TwitterClient.Tests
{
    public class TwtterBaseClientTests
    {
        private string _apikey;
        public TwtterBaseClientTests()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets("448180e3-246a-4987-ad61-016e753ee973")
                .Build();

            var secretProvider = config.Providers.First();
            secretProvider.TryGet("Twitter:apikey", out _apikey);
        }
        [Fact]
        public async Task Test1()
        {
            var client = new TwitterBaseClient(_apikey);

            var response = await client.GetRecentSearchAsync("from:damplin #toritojalisco");

            Assert.NotNull(response);
            Assert.NotEmpty(response.Data);
        }
    }
}
