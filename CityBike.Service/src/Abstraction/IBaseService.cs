using CityBike.Core.src.Shared;
using CityBike.Service.src.DTO;

namespace CityBike.Service.src.Abstraction
{
    public interface IBaseService<T, TReadDTO, TCreateDTO, TUpdateDTO>
    {
        Task<GetAllResponse<TReadDTO>> GetAllAsync(GetAllOptions options);
        Task<TReadDTO> GetByIdAsync(int id);
        Task<TReadDTO> CreateOneAsync(TCreateDTO createDTO);
        Task<TReadDTO> UpdateOneAsync(int id, TUpdateDTO updateDTO);
        Task<bool> DeleteOneAsync(int id);
    }
}