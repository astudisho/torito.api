using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;
using Torito.Models.Utils;

namespace Torito.Models.Twitter
{
    public class RecentSearchResponse
    {
        public IEnumerable<Twit> Data { get; set; }
        public MetaData Meta { get; set; }   
    }

    public class MetaData
    {
        public long NewestId { get; set; }
        public long OldestId { get; set; }

        [DeserializeAs(Name = Constants.Twitter.SerializeProperties.Metadata.Count)]
        public int Count { get; set; }
        public string NextToken { get; set; }
    }
}
