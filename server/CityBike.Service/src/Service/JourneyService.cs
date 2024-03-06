using AutoMapper;
using CityBike.Core.src.Abstraction;
using CityBike.Core.src.Entity;
using CityBike.Core.src.Shared;
using CityBike.Service.src.Abstraction;
using CityBike.Service.src.DTO;
using CityBike.Service.src.Shared;

namespace CityBike.Service.src.Service
{
    public class JourneyService(IJourneyRepo repo, IStationRepo stationRepo, IMapper mapper) : BaseService<Journey, JourneyReadDTO, JourneyCreateDTO, JourneyUpdateDTO>(repo, mapper), IJourneyService
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


        public override async Task<JourneyReadDTO> CreateOneAsync(JourneyCreateDTO journeyCreateDTO)
        {
            var newObject = _mapper.Map<JourneyCreateDTO, Journey>(journeyCreateDTO);
            Station departureStation = await stationRepo.GetByIdAsync(newObject.DepartureStationId) ?? throw CustomException.NotFound($"Data not found for ID: {newObject.DepartureStationId}");
            Station returnStation = await stationRepo.GetByIdAsync(newObject.ReturnStationId) ?? throw CustomException.NotFound($"Data not found for ID: {newObject.ReturnStationId}");

            var createdObject = await _repo.CreateOneAsync(newObject);

            createdObject.ReturnStation = returnStation;
            createdObject.DepartureStation = departureStation;

            return _mapper.Map<Journey, JourneyReadDTO>(createdObject);
        }



    }
}
