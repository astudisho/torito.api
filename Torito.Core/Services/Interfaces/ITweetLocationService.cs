using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Torito.Data.Persistance.DataModels;

namespace Torito.Core.Services.Interfaces
{
    public interface ITweetLocationService
    {
        Task<IList<TweetDbo>> AssignAddressTextToTweet(CancellationToken cancellationToken = default);

        Task<TweetDbo> AssignAddressObjectToTweet(TweetDbo tweetDbo, CancellationToken cancellationToken = default);
    }
}
