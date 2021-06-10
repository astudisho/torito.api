using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Torito.Core.Services.Interfaces
{
    public interface ISyncService
    {
        Task<int> SyncTweets(CancellationToken ct);
        Task<int> SyncAddress(CancellationToken ct);
        Task<int> SyncLocation(CancellationToken ct);
    }
}
