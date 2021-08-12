using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Models.Twitter;

namespace Torito.Models.Dtos
{
    public class ToritoDto
    {
        public ulong Id { get; set; }
        public string AddressText { get; set; }
        public string TweetText { get; set; }
        public LocationDto Location { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class LocationDto
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
