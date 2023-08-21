using LibraryManagementSystem.Domain.src.Shared;
using LibraryManagementSystem.Service.src.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controller.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    public class LibraryBaseController<T, TReadDto, TCreateDto, TUpdateDto> : ControllerBase
    {
        private readonly IBaseService<T, TReadDto, TCreateDto, TUpdateDto> _baseService;

        public LibraryBaseController(IBaseService<T, TReadDto, TCreateDto, TUpdateDto> baseService)
        {
            _baseService = baseService;
        }

        [HttpPost]
        public virtual async Task<ActionResult<TReadDto>> CreateOne([FromBody] TCreateDto dto)
        {
            TReadDto createdObject = await _baseService.CreateOne(dto);
            return CreatedAtAction("CreateOne", createdObject);
        }

        [HttpGet("{id:guid}")]
        public virtual async Task<ActionResult<IEnumerable<TReadDto>>> GetOne([FromRoute] Guid id)
        {
            return Ok(await _baseService.GetOne(id));  
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TReadDto>>> GetAll([FromQuery] QueryOptions queryOptions)
        {
            return Ok(await _baseService.GetAll(queryOptions));
        }

        [HttpPatch("{id:guid}")]
        public virtual async Task<ActionResult<TReadDto>> UpdateOne([FromRoute] Guid id, [FromBody] TUpdateDto updateDto)
        {
            TReadDto updatedEntity = await _baseService.UpdateOne(id, updateDto);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id:guid}")]
        public virtual async Task<ActionResult<bool>> DeleteOne([FromRoute] Guid id)
        {
            return Ok(await _baseService.DeleteOne(id));
        }
    }
}