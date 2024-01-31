using CityBike.Core.src.Abstraction;
using CityBike.Core.src.Shared;
using CityBike.WebApi.src.Database;
using Microsoft.EntityFrameworkCore;

namespace CityBike.WebApi.src.Repository
{
    public class BaseRepo<T>(DataBaseContext dataBaseContext) : IBaseRepo<T> where T : class
    {
        protected readonly DbSet<T> _data = dataBaseContext.Set<T>();
        protected readonly DataBaseContext _databaseContext = dataBaseContext;
        public virtual async Task<T> CreateOneAsync(T createObject)
        {
            _data.Add(createObject);
            await _databaseContext.SaveChangesAsync();

            return createObject;

        }

        public virtual async Task<bool> DeleteOneAsync(T deleteObject)
        {
            _data.Remove(deleteObject);
            await _databaseContext.SaveChangesAsync();

            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(GetAllOptions options)
        {

            var entities = await _data
                                .AsNoTracking()
                                .Skip(options.Offset)
                                .Take(options.Limit)
                                .ToArrayAsync();
            return entities;

        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            var result = await _data.FindAsync(id);

            return result;
        }

        public virtual async Task<int> GetTotal(GetAllOptions options)
        {
            var total = await _data.AsNoTracking().CountAsync();

            return total;
        }

        public virtual async Task<T> UpdateOneAsync(T updateObject)
        {
            _data.Update(updateObject);
            await _databaseContext.SaveChangesAsync();

            return updateObject;
        }
    }
}