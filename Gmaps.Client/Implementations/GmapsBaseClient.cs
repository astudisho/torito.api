using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gmaps.Client.Implementations
{
    public abstract class GmapsBaseClient
    {
        protected RestClient _client;
        protected IRestRequest _restRequest;
        private string _baseUrl => "https://maps.googleapis.com/maps/api/";

        public GmapsBaseClient(string apiKey)
        {
            _client = new RestClient(_baseUrl);

            _client.AddDefaultQueryParameter("key", apiKey);
        }
    }
}
