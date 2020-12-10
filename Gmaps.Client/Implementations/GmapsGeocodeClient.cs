using Gmaps.Client.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Models.GMaps;

namespace Gmaps.Client.Implementations
{
    public class GmapsGeocodeClient : GmapsBaseClient, IGmapsGeocodeClient
    {
        protected string ResponseType { get; set; } = "json";
        public GmapsGeocodeClient(string apikey) : base(apikey)
        {

        }

        public async Task<GeoCodeResponse> GetGeocodeForAddress(string address)
        {
            _restRequest = new RestRequest($"/geocode/{ResponseType}");
            _restRequest.AddQueryParameter("address", address, true);

            var response = await _client.GetAsync<GeoCodeResponse>(_restRequest);

            return response;
        }
    }
}
