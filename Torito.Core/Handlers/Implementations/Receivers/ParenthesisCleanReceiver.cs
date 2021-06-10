using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Torito.Data.Persistance.DataModels;

namespace Torito.Core.Handlers.Implementations
{
    public class ParenthesisCleanReceiver : IReceiver<TweetDbo>
    {
        public void Handle(TweetDbo request)
        {
            var regex = new Regex(@"\(.*\)", RegexOptions.Compiled);

            // When not match do not do anything.
            if (regex.IsMatch(request.AddressText))
            {
                var coincidence = regex.Match(request.AddressText).Value;

                request.AddressText = request.AddressText.Replace(coincidence, string.Empty);
            }
        }
    }
}
