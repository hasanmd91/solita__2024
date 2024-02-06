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




    }
}