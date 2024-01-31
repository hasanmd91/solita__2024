using CityBike.Core.src.Abstraction;
using CityBike.Core.src.Entity;
using CityBike.WebApi.src.Database;

namespace CityBike.WebApi.src.Repository
{
    public class JourneyRepo(DataBaseContext dataBaseContext) : BaseRepo<Journey>(dataBaseContext), IJourneyRepo
    {
    }
}