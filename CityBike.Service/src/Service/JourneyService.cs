using AutoMapper;
using CityBike.Core.src.Abstraction;
using CityBike.Core.src.Entity;
using CityBike.Core.src.Shared;
using CityBike.Service.src.Abstraction;
using CityBike.Service.src.DTO;

namespace CityBike.Service.src.Service
{
    public class JourneyService(IJourneyRepo repo, IMapper mapper) : BaseService<Journey, JourneyReadDTO, JourneyCreateDTO, JourneyUpdateDTO>(repo, mapper), IJourneyService
    {

        public override async Task<GetAllResponse<JourneyReadDTO>> GetAllAsync(GetAllOptions options)
        {
            var entities = await _repo.GetAllAsync(options);

            var readEntities = _mapper.Map<IEnumerable<Journey>, IEnumerable<JourneyReadDTO>>(entities);

            var total = await _repo.GetTotal(options);
            var pages = (int)Math.Ceiling((double)total / options.Limit);
            var result = new GetAllResponse<JourneyReadDTO> { Items = readEntities, Total = total, Pages = pages };

            return result;
        }



    }
}
