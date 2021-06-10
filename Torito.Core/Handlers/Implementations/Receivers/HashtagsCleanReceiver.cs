using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Torito.Data.Persistance.DataModels;

namespace Torito.Core.Handlers.Implementations
{
    public class HashtagsCleanReceiver : IReceiver<TweetDbo>
    {
        public  void Handle(TweetDbo tweet)
        {
            var hasHashTags = tweet.Entities?.Hashtags.Any() ?? false;

            if (hasHashTags)
            {
                tweet.Entities.Hashtags.ForEach(x => 
                {
                    var match = $"#{x.Tag}";
                    tweet.AddressText.Replace(match, string.Empty);
                });

                tweet.AddressText.Trim();
            }            
        }
    }
}
