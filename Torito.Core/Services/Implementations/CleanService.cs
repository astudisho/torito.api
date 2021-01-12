using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Torito.Core.Handlers.Implementations;
using Torito.Core.Handlers.Interfaces;
using Torito.Core.Services.Interfaces;
using Torito.Data.Persistance.DataModels;
using Torito.Models.Twitter;

namespace Torito.Core.Services.Implementations
{
    public class AddressCleanService : IAddressCleanService
    {
        private IHandler<TweetDbo> _tweetDboAddressCleanHandler;
        public AddressCleanService(IHandler<TweetDbo> tweetDboAddressCleanHandler)
        {
            _tweetDboAddressCleanHandler = tweetDboAddressCleanHandler;
        }
        public void SetAddressFromTweet(TweetDbo tweet)
        {
            _tweetDboAddressCleanHandler.Handle(tweet);
        }
    }
}
