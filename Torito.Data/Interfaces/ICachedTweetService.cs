using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Models.Twitter;

namespace Torito.Data.Interfaces
{
    public interface ICachedTweetService
    {
        Task<IList<Tweet>> GetLast100Tweets();
    }
}
