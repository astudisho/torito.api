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
            
        }
        [Fact]
        public void Should_Initialize_Client()
        {
            var client = new TwitterBaseClient(_apikey);            

            Assert.NotNull(client);
        }
    }
}
