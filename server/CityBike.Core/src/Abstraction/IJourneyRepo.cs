using CityBike.Core.src.Entity;

namespace CityBike.Core.src.Abstraction
{
    public interface IJourneyRepo : IBaseRepo<Journey>
    {
        Task<int> GetTotalDeparturesFromStationAsync(int stationId);
        Task<int> GetTotalArrivalsToStationAsync(int stationId);
        Task<int> GetAverageDistanceFromStationAsync(int stationId);
        Task<int> GetAverageDurationFromStationAsync(int stationId);
        Task<List<int>> GetTop5PopularReturnStationsAsync(int startingStationId);
        Task<List<int>> GetTop5PopularDepartureStationsAsync(int endingStationId);
    }
}