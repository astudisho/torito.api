using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torito.Models.Utils.Tools
{
    public class UserSecretManager
    {
        private IConfigurationProvider _secretProvider;
        public UserSecretManager()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets("448180e3-246a-4987-ad61-016e753ee973")
                .Build();

            _secretProvider = config.Providers.First();
        }

        public string GetTwitterApiKey()
        {
            _secretProvider.TryGet("Twitter:apikey", out var apikey);
            return apikey;
        }

        public string GetDataConnectionStringApiKey(string env = "dev")
        {
            _secretProvider.TryGet($"Data:ConnectionString:{env}", out var apikey);
            return apikey;
        }

        public string GetGmapsGeocodeApiKey()
        {
            _secretProvider.TryGet($"Gmaps:Geocode:Apikey", out var apikey);
            return apikey;
        }
    }
}
