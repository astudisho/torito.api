using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Torito.Data.Persistance.DataModels;

namespace Torito.Core.Handlers.Implementations
{
    public class RetweetCleanReceiver : IReceiver<TweetDbo>
    {
        public void Handle(TweetDbo request)
        {
            var regex = new Regex(@"(?<=RT @damplin:)(.*)(?=\s)");

            var match = regex.Match(request.AddressText);
            //var isRetweet = regex.IsMatch(request.AddressText);

            // When not match do not do anything.
            if (match.Success)
            {
                var result = match.Value;
                request.AddressText = result.Trim();

                //request.AddressText = request.AddressText.Replace(match, string.Empty);
            }
        }
    }
}
