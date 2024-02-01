using AutoMapper;
using CityBike.Core.src.Abstraction;
using CityBike.Core.src.Entity;
using CityBike.Service.src.Abstraction;
using CityBike.Service.src.DTO;

namespace CityBike.Service.src.Service
{
    public class StationService(IBaseRepo<Station> repo, IMapper mapper) : BaseService<Station, StationReadDTO, StationCreateDTO, StationUpdateDTO>(repo, mapper), IStationService
    {
    }
}