using AutoMapper;
using real_estate_market.Controllers.Resources;
using real_estate_market.Models;

namespace real_estate_market.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cladding, CladdingResource>();
            CreateMap<RealEstate, RealEstateResource>();
        }
    }
}