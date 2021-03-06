﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Torito.Models.Twitter;

namespace Torito.Data.Interfaces
{
    public interface ICachedTweetService
    {
        Task<IList<Tweet>> FetchAndUpdateLast100Tweets(CancellationToken ct = default);
    }
}
