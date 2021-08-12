using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Torito.Models.Dtos;

namespace Torito.Core.Services.Interfaces
{
    public interface IRecentTweetService
    {
        Task<IList<ToritoDto>> GetRecentTorito(CancellationToken cancellationToken);
        Task<IList<ToritoDto>> GetLastDayTorito(CancellationToken ct = default);
    }
}
