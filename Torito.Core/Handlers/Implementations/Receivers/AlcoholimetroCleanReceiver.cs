using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Torito.Data.Persistance.DataModels;

namespace Torito.Core.Handlers.Implementations.Receivers
{
    public class AlcoholimetroCleanReceiver : IReceiver<TweetDbo>
    {
        public void Handle(TweetDbo tweet)
        {
            // Remove "Torito:" word and first new line.
            var alcoholimetroRegex = new Regex(@"(?<=(Alcoholimetro|Alcoholímetro):)((.|\s)*)", RegexOptions.Compiled);
            var match = alcoholimetroRegex.Match(tweet.AddressText);
            if (match.Success)
            {
                var result = match.Value;
                tweet.AddressText = result.Trim();
            }
        }
    }
}
