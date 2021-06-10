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
        public void Handle(TweetDbo tweet)
        {
            // Remove last part, before the last newline.
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            var regex = new Regex(@"(.|\s)*(?=\n)", RegexOptions.Compiled);

            var match = regex.Match(tweet.AddressText);

            if(match.Success)
            {
                var result = match.Value;
                tweet.AddressText = result.Trim();
            }            

            stopwatch.Stop();

            System.Diagnostics.Debug.WriteLine($"Elapsed: {stopwatch.Elapsed}");            
        }
    }
}
