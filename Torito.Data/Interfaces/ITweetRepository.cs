using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Torito.Models.Twitter;

namespace Torito.Data.Interfaces
{
    public interface ITweetRepository
    {
        Task<IList<Tweet>> GetLast100ToritoTweets(CancellationToken ct);
        Task<IList<Tweet>> GetTopToritoTweets(int count, CancellationToken ct);
    }
}
