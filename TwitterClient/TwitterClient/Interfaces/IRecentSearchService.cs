using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Torito.Models.Twitter;

namespace TwitterClient.Interfaces
{
    public interface IRecentSearchService
    {
        Task<RecentSearchResponse> GetRecentSearchAsync(string query, RecentSearchRequestParameters parameters, CancellationToken ct = default);
    }
}
