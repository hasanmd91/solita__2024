using CityBike.Core.src.Shared;

namespace CityBike.Core.src.Abstraction
{
    public interface IBaseRepo<T>
    {
        Task<IEnumerable<T>> GetAllAsync(GetAllOptions options);
        Task<int> GetTotal(GetAllOptions options);
        Task<T?> GetByIdAsync(int id);
        Task<T> CreateOneAsync(T createObject);
        Task<T> UpdateOneAsync(T updateObject);
        Task<bool> DeleteOneAsync(T deleteObject);

    }
}