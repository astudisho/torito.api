using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Data.Persistance.DataModels;
using Torito.Data.Persistance.DataModels.Gmaps;
using Torito.Models.GMaps;
using Torito.Models.Twitter;

namespace Torito.Data.Utils.Mappings
{
    public class DataMapperProfile : Profile
    {
        public DataMapperProfile()
        {
            CreateMap<TweetDbo, Tweet>().ReverseMap();
            CreateMap<Entities, EntityDbo>().ReverseMap();
            CreateMap<Hashtag, HashtagDbo>().ReverseMap();
            CreateMap<Annotation, AnnotationDbo>().ReverseMap();
            CreateMap<Result, ResultDbo>().ReverseMap();
            CreateMap<GeoCodeResponse, GeocodeDbo>().ReverseMap();
            CreateMap<Result, ResultDbo>().ReverseMap();
            CreateMap<AddressComponent, AddressComponentDbo>().ReverseMap();
            CreateMap<Geometry, GeometryDbo>().ReverseMap();
            CreateMap<Location, LocationDbo>()
                //.Include(typeof(Northeast), typeof(NortheastDbo))
                //.Include(typeof(Southwest), typeof(SouthwestDbo))
                .ReverseMap();
            CreateMap<Northeast, NortheastDbo>().ReverseMap();
            CreateMap<Southwest, SouthwestDbo>().ReverseMap();
            CreateMap<Viewport, ViewportDbo>().ReverseMap();
            CreateMap<PlusCode, PlusCodeDbo>().ReverseMap();
        }   
    }
}
