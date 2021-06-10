using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Data.Persistance.DataModels;
using Torito.Models.Twitter;

namespace Torito.Core.Services.Interfaces
{
    public interface IAddressCleanService
    {
        void SetAddressFromTweet(TweetDbo tweet);        
    }
}
