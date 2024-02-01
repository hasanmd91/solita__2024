using AutoMapper;
using CityBike.Core.src.Abstraction;
using CityBike.Core.src.Entity;
using CityBike.Service.src.Abstraction;
using CityBike.Service.src.DTO;

namespace CityBike.Service.src.Service
{
    public class JourneyService(IJourneyRepo repo, IMapper mapper) : BaseService<Journey, JourneyReadDTO, JourneyCreateDTO, JourneyUpdateDTO>(repo, mapper), IJourneyService
    {
    }
}