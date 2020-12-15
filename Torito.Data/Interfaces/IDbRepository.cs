using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Torito.Data.Persistance.DataModels;

namespace Torito.Data.Interfaces
{
    public interface ITweetDbRepository
    {
        Task<int> AddList(IEnumerable<TweetDbo> data, CancellationToken cancellationToken = default);
        Task<IList<TweetDbo>> GetAll(CancellationToken cancellationToken = default);
        Task<IList<TweetDbo>> GetLast100ToritoTweets(CancellationToken cancellationToken = default);
    }
}
