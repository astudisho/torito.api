using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Data.Persistance.DataModels;
using Torito.Models.Twitter;

namespace Torito.Data.Utils.Mappings
{
    public class DataMapperProfile : Profile
    {
        public DataMapperProfile()
        {
            CreateMap<TweetDbo, Tweet>()
                .ReverseMap();
            CreateMap<Entities, EntityDbo>()
                .ReverseMap();
            CreateMap<Hashtag, HashtagDbo>()
                .ReverseMap();
            CreateMap<Annotation, AnnotationDbo>()
                .ReverseMap();
        }   
    }
}
