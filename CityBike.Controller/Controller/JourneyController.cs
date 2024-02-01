using CityBike.Core.src.Entity;
using CityBike.Service.src.Abstraction;
using CityBike.Service.src.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CityBike.Controller.Controller
{
    [Route("[controller]")]
    public class JourneyController(IBaseService<Journey, JourneyReadDTO, JourneyCreateDTO, JourneyUpdateDTO> service) : BaseController<Journey, JourneyReadDTO, JourneyCreateDTO, JourneyUpdateDTO>(service)
    {
    }
}