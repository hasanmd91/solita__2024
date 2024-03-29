using AutoMapper;
using CityBike.Core.src.Entity;
using CityBike.Service.src.DTO;

namespace CityBike.Service.src.Shared
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Station, StationReadDTO>();
            CreateMap<StationCreateDTO, Station>();
            CreateMap<StationUpdateDTO, Station>()
                .ForAllMembers(opt => opt.Condition((src, dest, member) => member != null));

            CreateMap<Journey, JourneyReadDTO>()
                .ForMember(dest => dest.DepartureStationName, opt => opt.MapFrom(src => src.DepartureStation.Name))
                .ForMember(dest => dest.ReturnStationName, opt => opt.MapFrom(src => src.ReturnStation.Name));

            CreateMap<JourneyCreateDTO, Journey>();
            CreateMap<JourneyUpdateDTO, Journey>()
                .ForAllMembers(opt => opt.Condition((src, dest, member) => member != null));
        }
    }
}