using CityBike.Core.src.Abstraction;
using CityBike.Core.src.Entity;
using CityBike.Core.src.Shared;
using CityBike.WebApi.src.Database;
using Microsoft.EntityFrameworkCore;

namespace CityBike.WebApi.src.Repository
{
    public class StationRepo(DataBaseContext dataBaseContext) : BaseRepo<Station>(dataBaseContext), IStationRepo
    {
        public override async Task<IEnumerable<Station>> GetAllAsync(GetAllOptions options)
        {
            var query = _data.AsNoTracking();

            if (!string.IsNullOrEmpty(options.OrderBy))
            {
                query = ApplyOrderBy(query, options.OrderBy, options.SortDirection ?? "Desc");
            }
            var entities = await query
                                .Skip(options.Offset)
                                .Take(options.Limit)
                                .ToArrayAsync();
            return entities;
        }

        private static IQueryable<Station> ApplyOrderBy(IQueryable<Station> stations, string? orderBy, string sortDirection = "desc")
        {
            bool descending = sortDirection.Equals("desc", StringComparison.OrdinalIgnoreCase);

            return (orderBy?.ToLower()) switch
            {
                "capacity" => descending
                                   ? stations.OrderByDescending(s => s.Capacity)
                                   : stations.OrderBy(s => s.Capacity),

                "name" => descending
                                   ? stations.OrderByDescending(s => s.Name)
                                   : stations.OrderBy(s => s.Name),

                "city" => descending
                                   ? stations.OrderByDescending(s => s.City)
                                   : stations.OrderBy(s => s.City),

                _ => descending
                                   ? stations.OrderByDescending(s => s.Name)
                                   : stations.OrderBy(s => s.Name),

            };
        }


        public override async Task<Station> CreateOneAsync(Station createObject)
        {

            var highestId = _data.OrderByDescending(s => s.Id).FirstOrDefault()?.Id ?? 0;
            var newId = highestId++;

            var Station = new Station
            {
                Id = newId,
                Name = createObject.Name,
                Address = createObject.Address,
                City = createObject.City,
                Capacity = createObject.Capacity,
                X = createObject.X,
                Y = createObject.Y
            };

            _data.Add(Station);
            await _databaseContext.SaveChangesAsync();
            return Station;

        }

    }

}