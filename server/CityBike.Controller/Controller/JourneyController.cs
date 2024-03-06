using CityBike.Core.src.Entity;
using CityBike.Service.src.Abstraction;
using CityBike.Service.src.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CityBike.Controller.Controller
{
    [Route("api/v1/[controller]")]
    public class JourneyController(IJourneyService service) : BaseController<Journey, JourneyReadDTO, JourneyCreateDTO, JourneyUpdateDTO>(service)
    {
    }
}