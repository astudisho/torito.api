using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Torito.Data.Persistance.DataModels;

namespace Torito.Core.Handlers.Implementations
{
    public class AddressCleanReceiver : IReceiver<TweetDbo>
    {
        public  void Handle(TweetDbo tweet)
        {
            var separator = "|";
            var regex = new Regex(@"\n\s*#");
            var replacedString = regex.Replace(tweet.Text, separator,1);
            var firstIndex = replacedString.IndexOf(':');
            //var substring = tweet.Text.Replace("\n#","|");
            var lastIndex = replacedString.IndexOf(separator);

            var result = replacedString.Substring(firstIndex + 1, lastIndex - firstIndex - 1).Trim();

            tweet.AddressText = result;
        }
    }
}
