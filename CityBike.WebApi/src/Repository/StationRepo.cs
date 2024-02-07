using CityBike.Core.src.Abstraction;
using CityBike.Core.src.Entity;
using CityBike.WebApi.src.Database;

namespace CityBike.WebApi.src.Repository
{
    public class StationRepo(DataBaseContext dataBaseContext) : BaseRepo<Station>(dataBaseContext), IStationRepo
    {

    }

}