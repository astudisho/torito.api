using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Torito.Models.Twitter;

namespace Torito.Data.Interfaces
{
    public interface ITweetRepository
    {
        Task<IList<Tweet>> GetLast100ToritoTweets();
        Task<IList<Tweet>> GetTopToritoTweets(int count);
    }
}
