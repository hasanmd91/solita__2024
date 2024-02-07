using AutoMapper;
using CityBike.Core.src.Abstraction;
using CityBike.Core.src.Entity;
using CityBike.Service.src.Abstraction;
using CityBike.Service.src.DTO;
using CityBike.Service.src.Shared;


namespace CityBike.Service.src.Service
{
    public class StationService(IStationRepo stationRepo, IJourneyRepo journeyRepo, IMapper mapper) : BaseService<Station, StationReadDTO, StationCreateDTO, StationUpdateDTO>(stationRepo, mapper), IStationService
    {
        private readonly IStationRepo stationRepo = stationRepo;
        private readonly IJourneyRepo journeyRepo = journeyRepo;

        public async Task<StationMetricsDTO> GetStationMetricsAsync(int stationId)
        {
            var station = await stationRepo.GetByIdAsync(stationId) ?? throw CustomException.NotFound($"Station not found for ID: {stationId}");

            var totalDepartures = await journeyRepo.GetTotalDeparturesFromStationAsync(stationId);
            var totalArrivals = await journeyRepo.GetTotalArrivalsToStationAsync(stationId);
            var averageDistance = await journeyRepo.GetAverageDistanceFromStationAsync(stationId);
            var averageDuration = await journeyRepo.GetAverageDurationFromStationAsync(stationId);
            var popularReturnStations = await GetStationNames(await journeyRepo.GetTop5PopularReturnStationsAsync(stationId));
            var popularDepartureStations = await GetStationNames(await journeyRepo.GetTop5PopularDepartureStationsAsync(stationId));

            var stationStatistics = new StationMetricsDTO
            {
                Id = station.Id,
                Name = station.Name,
                Address = station.Address,
                City = station.City,
                Capacity = station.Capacity,
                TotalDepartures = totalDepartures,
                TotalArrivals = totalArrivals,
                AverageDistance = averageDistance,
                AverageDuration = averageDuration,
                Top5popularDepartureStations = popularDepartureStations,
                Top5popularReturnStations = popularReturnStations,
                X = station.X,
                Y = station.Y,
            };

            return stationStatistics;
        }

        public async Task<List<string>> GetStationNames(List<int> stationIds)
        {
            var stationNames = new List<string>();
            foreach (var stationId in stationIds)
            {
                var station = await stationRepo.GetByIdAsync(stationId);
                if (station != null)
                {
                    stationNames.Add(station.Name);
                }
            }
            return stationNames;
        }
    }
}
