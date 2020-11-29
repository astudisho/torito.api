using RestSharp;
using RestSharp.Authenticators;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Torito.Models.Twitter;

namespace TwitterClient
{
    public class TwitterBaseClient
    {
        protected RestClient _client;
        private string _baseUrl => "https://api.twitter.com/";

        public TwitterBaseClient(string apiKey)
        {
            _client = new RestClient(_baseUrl);

            _client.AddDefaultHeader("Authorization", $"Bearer {apiKey}");
        }        

        protected virtual void AddQueryParameters(IRequestParameters requestParameters)
        {
            var properties = requestParameters.GetType().GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(requestParameters);

                if (value == null) continue;

                var description = Attribute.IsDefined(property, typeof(DescriptionAttribute)) ?
                    (Attribute.GetCustomAttribute(property, typeof(DescriptionAttribute)) as DescriptionAttribute).Description :
                    property.Name;

                _client.AddDefaultQueryParameter(description, value.ToString());
            }
        }
    }
}
