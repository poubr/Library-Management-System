using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Service.src.Abstractions;
using LibraryManagementSystem.Service.src.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controller.src.Controllers
{
    public class BookController : LibraryBaseController<Book, BookReadDto, BookCreateDto, BookUpdateDto>
    {
        private readonly IBookService _bookService;

        public BookController(IBookService baseService) : base(baseService)
        {
            _bookService = baseService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<BookReadDto>> CreateOne([FromBody] BookCreateDto dto)
        {
            BookReadDto createdObject = await _bookService.CreateOne(dto);
            return CreatedAtAction("Created", createdObject);
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{id:Guid}")]
        public override async Task<ActionResult<BookReadDto>> UpdateOne([FromRoute] Guid id, [FromBody] BookUpdateDto updateDto)
        {
            BookReadDto updatedEntity = await _bookService.UpdateOne(id, updateDto);
            return Ok(updatedEntity);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:Guid}")]
        public override async Task<ActionResult<bool>> DeleteOne([FromRoute] Guid id)
        {
            return Ok(await _bookService.DeleteOne(id));
            // TODO:
            // NoContent() might be a better option here,
            // change when doing the errors and having if elses
        }
    }
}