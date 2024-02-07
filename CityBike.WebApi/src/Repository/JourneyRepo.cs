using CityBike.Core.src.Abstraction;
using CityBike.Core.src.Entity;
using CityBike.Core.src.Shared;
using CityBike.WebApi.src.Database;
using Microsoft.EntityFrameworkCore;

namespace CityBike.WebApi.src.Repository
{
    public class JourneyRepo(DataBaseContext dataBaseContext) : BaseRepo<Journey>(dataBaseContext), IJourneyRepo
    {


        public override async Task<IEnumerable<Journey>> GetAllAsync(GetAllOptions options)
        {
            var query = _data.AsNoTracking();

            if (!string.IsNullOrEmpty(options.OrderBy))
            {
                query = ApplyOrderBy(query, options.OrderBy, options.SortDirection ?? "Desc");
            }
            var entities = await query
                                .Include(j => j.DepartureStation)
                                .Include(j => j.ReturnStation)
                                .Skip(options.Offset)
                                .Take(options.Limit)
                                .ToArrayAsync();
            return entities;
        }

        private static IQueryable<Journey> ApplyOrderBy(IQueryable<Journey> journeys, string? orderBy = "departureDateTime", string sortDirection = "desc")
        {
            bool descending = sortDirection.Equals("desc", StringComparison.OrdinalIgnoreCase);

            return (orderBy?.ToLower()) switch
            {
                "departuredatetime" => descending
                    ? journeys.OrderByDescending(j => j.DepartureDateTime)
                    : journeys.OrderBy(j => j.DepartureDateTime),

                "returndatetime" => descending
                    ? journeys.OrderByDescending(j => j.ReturnDateTime)
                    : journeys.OrderBy(j => j.ReturnDateTime),

                "covereddistance" => descending
                    ? journeys.OrderByDescending(j => j.CoveredDistance)
                    : journeys.OrderBy(j => j.CoveredDistance),

                "duration" => descending
                    ? journeys.OrderByDescending(j => j.Duration)
                    : journeys.OrderBy(j => j.Duration),

                _ => journeys.OrderByDescending(j => j.DepartureDateTime),
            };
        }

        public async Task<int> GetTotalDeparturesFromStationAsync(int stationId)
        {
            return await _data.CountAsync(j => j.DepartureStationId == stationId);
        }

        public async Task<int> GetTotalArrivalsToStationAsync(int stationId)
        {
            return await _data.CountAsync(j => j.ReturnStationId == stationId);
        }

        public async Task<int> GetAverageDistanceFromStationAsync(int stationId)
        {
            return (int)await _data.Where(j => j.DepartureStationId == stationId).AverageAsync(j => j.CoveredDistance);
        }

        public async Task<int> GetAverageDurationFromStationAsync(int stationId)
        {
            return (int)await _data.Where(j => j.DepartureStationId == stationId).AverageAsync(j => j.Duration);
        }
        public async Task<List<int>> GetTop5PopularReturnStationsAsync(int startingStationId)
        {
            return await _data
                   .Where(j => j.DepartureStationId == startingStationId)
                   .GroupBy(j => j.ReturnStationId)
                   .OrderByDescending(g => g.Count())
                   .Select(g => g.Key)
                   .Take(5)
                   .ToListAsync();
        }

        public async Task<List<int>> GetTop5PopularDepartureStationsAsync(int endingStationId)
        {
            return await _data
                .Where(j => j.ReturnStationId == endingStationId)
                .GroupBy(j => j.DepartureStationId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .Take(5)
                .ToListAsync();
        }
    }
}