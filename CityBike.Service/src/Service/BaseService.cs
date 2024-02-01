using AutoMapper;
using CityBike.Core.src.Abstraction;
using CityBike.Core.src.Shared;
using CityBike.Service.src.Abstraction;
using CityBike.Service.src.DTO;
using CityBike.Service.src.Shared;

namespace CityBike.Service.src.Service
{
    public class BaseService<T, TReadDTO, TCreateDTO, TUpdateDTO>(IBaseRepo<T> repo, IMapper mapper) : IBaseService<T, TReadDTO, TCreateDTO, TUpdateDTO>
    {
        protected readonly IBaseRepo<T> _repo = repo;
        protected readonly IMapper _mapper = mapper;

        public virtual async Task<TReadDTO> CreateOneAsync(TCreateDTO createDTO)
        {
            var newObject = _mapper.Map<TCreateDTO, T>(createDTO);
            var createdObject = await _repo.CreateOneAsync(newObject);

            return _mapper.Map<T, TReadDTO>(createdObject);
        }

        public virtual async Task<bool> DeleteOneAsync(int id)
        {
            var deleteObject = await _repo.GetByIdAsync(id)
              ?? throw CustomException.NotFound();

            var result = await _repo.DeleteOneAsync(deleteObject);

            return result;
        }

        public virtual async Task<GetAllResponse<TReadDTO>> GetAllAsync(GetAllOptions options)
        {
            var entities = await _repo.GetAllAsync(options);

            var readEntities = _mapper.Map<IEnumerable<T>, IEnumerable<TReadDTO>>(entities);

            var total = await _repo.GetTotal(options);

            var pages = (int)Math.Ceiling((double)total / options.Limit);

            var result = new GetAllResponse<TReadDTO> { Items = readEntities, Total = total, Pages = pages };

            return result;
        }

        public virtual async Task<TReadDTO> GetByIdAsync(int id)
        {
            var result = await _repo.GetByIdAsync(id)
              ?? throw CustomException.NotFound();

            return _mapper.Map<T, TReadDTO>(result);
        }

        public virtual async Task<TReadDTO> UpdateOneAsync(int id, TUpdateDTO updateDTO)
        {
            var originalEntity = await _repo.GetByIdAsync(id)
              ?? throw CustomException.NotFound();

            var updatedEntity = _mapper.Map(updateDTO, originalEntity);

            var result = await _repo.UpdateOneAsync(updatedEntity);

            return _mapper.Map<T, TReadDTO>(result);
        }
    }
}