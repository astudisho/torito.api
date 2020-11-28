using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Torito.Models.Twitter
{
    public class Twit
    {
        public long? Id { get; set; }
        public string Text { get; private set; }
        public long? AuthorId { get; set; }
    }
}
