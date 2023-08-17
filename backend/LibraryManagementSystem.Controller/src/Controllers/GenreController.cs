using System.Data.Common;
using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Service.src.Abstractions;
using LibraryManagementSystem.Service.src.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controller.src.Controllers
{
    public class GenreController : LibraryBaseController<Genre, GenreReadDto, GenreCreateDto, GenreUpdateDto>
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService baseService) : base(baseService)
        {
            _genreService = baseService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public override async Task<ActionResult<GenreReadDto>> CreateOne([FromBody] GenreCreateDto dto)
        {
            GenreReadDto createdObject = await _genreService.CreateOne(dto);
            return CreatedAtAction("CreateOne", createdObject);
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{id:guid}")]
        public override async Task<ActionResult<GenreReadDto>> UpdateOne([FromRoute] Guid id, [FromBody] GenreUpdateDto updateDto)
        {
            GenreReadDto updatedEntity = await _genreService.UpdateOne(id, updateDto);
            return Ok(updatedEntity);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:guid}")]
        public override async Task<ActionResult<bool>> DeleteOne([FromRoute] Guid id)
        {
            return Ok(await _genreService.DeleteOne(id));
            // TODO:
            // NoContent() might be a better option here,
            // change when doing the errors and having if elses
        }
    }
}