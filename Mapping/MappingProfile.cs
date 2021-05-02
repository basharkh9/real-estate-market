using AutoMapper;
using real_estate_market.Controllers.Resources;
using real_estate_market.Models;

namespace real_estate_market.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Cladding, CladdingResource>();
            CreateMap<RealEstate, RealEstateResource>();

            // API Resource to Domain
            CreateMap<RealEstateResource, RealEstate>()
                .ForMember(r => r.Id, opt => opt.Ignore());
        }
    }
}