using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Torito.Models.GMaps;

namespace Gmaps.Client.Interfaces
{
    public interface IGmapsGeocodeClient
    {
        Task<GeoCodeResponse> GetGeocodeForAddress(string address, CancellationToken cancellationToken = default);
    }
}
