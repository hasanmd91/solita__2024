using CityBike.Core.src.Entity;
using CityBike.Service.src.Abstraction;
using CityBike.Service.src.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CityBike.Controller.Controller
{
    [Route("api/v1/[controller]")]
    public class StationController(IBaseService<Station, StationReadDTO, StationCreateDTO, StationUpdateDTO> service) : BaseController<Station, StationReadDTO, StationCreateDTO, StationUpdateDTO>(service)
    {
    }
}