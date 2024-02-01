using CityBike.Core.src.Shared;
using CityBike.Service.src.Abstraction;
using CityBike.Service.src.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityBike.Controller.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BaseController<T, TReadDTO, TCreateDTO, TUpdateDTO>(IBaseService<T, TReadDTO, TCreateDTO, TUpdateDTO> service) : ControllerBase where T : class
    {
        protected readonly IBaseService<T, TReadDTO, TCreateDTO, TUpdateDTO> _service = service;

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<ActionResult<TReadDTO>> CreateOneAsync([FromBody] TCreateDTO createDTO)
        {
            var createdObject = await _service.CreateOneAsync(createDTO);
            return CreatedAtAction(nameof(CreateOneAsync), createdObject);
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<bool>> DeleteOneAsync([FromRoute] Guid id)
        {
            var result = await _service.DeleteOneAsync(id);

            return Ok(result);
        }

        [HttpGet()]
        public virtual async Task<ActionResult<GetAllResponse<TReadDTO>>> GetAllAsync([FromQuery] GetAllOptions options)
        {
            var result = await _service.GetAllAsync(options);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TReadDTO>> GetByIdAsync([FromRoute] Guid id)
        {
            var result = await _service.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPatch("{id}")]
        public virtual async Task<ActionResult<TReadDTO>> UpdateOneAsync([FromRoute] Guid id, [FromBody] TUpdateDTO updateDTO)
        {
            var result = await _service.UpdateOneAsync(id, updateDTO);

            return Ok(result);
        }

    }
}