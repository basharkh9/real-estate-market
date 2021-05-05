using AutoMapper;
using real_estate_market.Controllers.Resources;
using real_estate_market.Core.Models;

namespace real_estate_market.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Feedback, FeedbackResource>();
            CreateMap<Photo, PhotoResource>();
            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));
            CreateMap<Cladding, CladdingResource>();
            CreateMap<RealEstate, SaveRealEstateResource>();
            CreateMap<RealEstate, RealEstateResource>();

            // API Resource to Domain
            CreateMap<FeedbackResource, Feedback>();
            CreateMap<RealEstateQueryResource, RealEstateQuery>();
            CreateMap<SaveRealEstateResource, RealEstate>()
                .ForMember(r => r.Id, opt => opt.Ignore());
        }
    }
}