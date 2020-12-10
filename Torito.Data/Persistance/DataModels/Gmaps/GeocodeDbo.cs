using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torito.Data.Persistance.DataModels.Gmaps
{
    class GeocodeDbo
    {
        public int Id { get; set; }

    }

    public class AddressComponentDbo
    {
        public string LongName { get; set; }

        public string ShortName { get; set; }

        public List<string> Types { get; set; }
    }

    public class LocationDbo
    {
        public double Lat { get; set; }

        public double Lng { get; set; }
    }

    public class NortheastDbo : LocationDbo
    {
    }

    public class SouthwestDbo : LocationDbo
    {
    }

    public class ViewportDbo
    {
        public NortheastDbo Northeast { get; set; }

        public SouthwestDbo Southwest { get; set; }
    }

    public class GeometryDbo
    {
        public LocationDbo Location { get; set; }

        public string LocationType { get; set; }

        public ViewportDbo Viewport { get; set; }
    }

    public class PlusCodeDbo
    {
        public string CompoundCode { get; set; }

        public string GlobalCode { get; set; }
    }

    public class ResultDbo
    {
        public List<AddressComponentDbo> AddressComponents { get; set; }

        public string FormattedAddress { get; set; }

        public GeometryDbo Geometry { get; set; }

        public string PlaceId { get; set; }

        public PlusCodeDbo PlusCode { get; set; }

        public List<string> Types { get; set; }
    }
}