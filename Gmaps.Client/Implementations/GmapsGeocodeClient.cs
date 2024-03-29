﻿using Gmaps.Client.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Torito.Models.GMaps;
using Gmaps.Client.Utils;

namespace Gmaps.Client.Implementations
{
    public class GmapsGeocodeClient : GmapsBaseClient, IGmapsGeocodeClient
    {
        protected string ResponseType { get; set; } = "json";
        public GmapsGeocodeClient(string apikey) : base(apikey)
        {

        }

        public async Task<GeoCodeResponse> GetGeocodeForAddress(string address, CancellationToken cancellationToken = default)
        {
            _restRequest = new RestRequest($"/geocode/{ResponseType}");
            _restRequest.AddQueryParameter("address", address, true);

            var response = await _client.GetAsync<GeoCodeResponse>(_restRequest, cancellationToken);

            ///TODO
            ///Handle response status.
            ///Create service to handle exceptions and other errors.
            if (response.Status != Constants.GmapsClient.OkStatus)
            {
                if(response.Status != Constants.GmapsClient.ZeroResults)
                    throw new ApplicationException($"GmapsGeocodeClient.GetGeocodeForAddress returns response.status: {response.Status}");
            } 

            return response;
        }
    }
}
