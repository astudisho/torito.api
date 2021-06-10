using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Data.Persistance.DataModels;
using Torito.Models.Utils;

namespace Torito.Core.Handlers.Implementations.Receivers
{
    public class IconCleanReceiver : IReceiver<TweetDbo>
    {
        protected string[] icons => 
            new string[] { "🍷", "🍸", "🍹", "🍺", "🍻", "🍾", "🚔", "👮", "🚓", "🐂" };
        public void Handle(TweetDbo request)
        {
            var containsAnyIcon = icons.Any(x => request.AddressText.Contains(x));

            if (containsAnyIcon)
            {
                icons.Select(x => request.AddressText.Replace(x, string.Empty));

                request.AddressText.Trim();
            }
        }
    }
}
