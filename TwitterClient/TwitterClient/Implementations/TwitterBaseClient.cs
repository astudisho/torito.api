using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections;
using System.ComponentModel;
using System.Threading.Tasks;
using Torito.Models.Twitter;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TwitterClient
{
    public class TwitterBaseClient
    {
        protected RestClient _client;
        protected IRestRequest _restRequest;
        
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

                // If propery is null, continue with next.
                if (value == null)  continue;

                // If property is not null, continue with logic.

                var description = Attribute.IsDefined(property, typeof(DescriptionAttribute)) ?
                    (Attribute.GetCustomAttribute(property, typeof(DescriptionAttribute)) as DescriptionAttribute).Description :
                    property.Name;

                var isEnumerableNonString = typeof(IEnumerable).IsAssignableFrom(property.PropertyType) 
                                            && property.PropertyType != typeof(string);

                string parameter;
                // If is enumerable, convert to list of strings
                if (isEnumerableNonString)
                {
                    var type = property.PropertyType;
                    var attributes = type.CustomAttributes;

                    var enumerable = value as List<string>;

                    parameter = value.ToString();

                    parameter = enumerable.Aggregate((x, y) => $"{x.ToString()},{y.ToString()}");
                }
                // Else convert to string
                else
                {
                    parameter = value.ToString();
                }

                _restRequest.AddQueryParameter(description, parameter);
            }
        }
    }
}
