using CityBike.Core.src.Entity;
using CityBike.Service.src.DTO;

namespace CityBike.Service.src.Abstraction
{
    public interface IStationService : IBaseService<Station, StationReadDTO, StationCreateDTO, StationUpdateDTO>
    {

    }
}