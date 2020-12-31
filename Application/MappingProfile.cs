using Application.Cities;
using AutoMapper;
using Domain;

namespace Application.Locations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Location, LocationDTO>()
                .ForMember(d => d.City, o => o.MapFrom(s => s.City.Name)).ReverseMap();
            CreateMap<Location, LocationDetailDTO>()
                         .ForMember(d => d.City, o => o.MapFrom(s => s.City.Id)).ReverseMap();
            CreateMap<City, CityDTO>().ReverseMap();
        }
    }
}