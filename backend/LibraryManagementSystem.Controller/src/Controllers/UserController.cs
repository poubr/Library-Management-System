using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Service.src.Dtos;
using LibraryManagementSystem.Service.src.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using LibraryManagementSystem.Domain.src.Shared;

namespace LibraryManagementSystem.Controller.src.Controllers
{
    [Authorize]
    public class UserController : LibraryBaseController<User, UserReadDto, UserCreateDto, UserUpdateDto> 
    {
        private readonly IUserService _userService;

        public UserController(IUserService baseService) : base(baseService)
        {
            _userService = baseService;
        }

        [HttpPatch("createadmin/{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<bool>> CreateAdmin([FromRoute]Guid id)
        {
            return Ok(await _userService.CreateAdmin(id));
        }

        [HttpPatch("updatepassword/{id:guid}")]
        public async Task<ActionResult<UserReadDto>> UpdatePassword([FromRoute] Guid id, [FromBody] string newPassword)
        {
            return Ok(await _userService.UpdatePassword(id, newPassword));
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{id:guid}")]
        public override async Task<ActionResult<UserReadDto>> UpdateOne([FromRoute] Guid id, [FromBody] UserUpdateDto updateDto)
        {
            UserReadDto updatedEntity = await _userService.UpdateOne(id, updateDto);
            return Ok(updatedEntity);
        }   

        [HttpPatch()]       // not sure if this the right way though
        public async Task<ActionResult<UserReadDto>> UpdateSelf([FromBody] UserUpdateDto updateDto)
        {
            string id = HttpContext.User.Claims.FirstOrDefault(
				c => c.Type == 
				ClaimTypes.NameIdentifier)!.Value;
            Guid guid = Guid.Parse(id);
            UserReadDto updatedEntity = await _userService.UpdateOne(guid, updateDto);
            return Ok(updatedEntity);
        }

        [AllowAnonymous]
        [HttpPost]
        public override async Task<ActionResult<UserReadDto>> CreateOne([FromBody] UserCreateDto dto)
        {
            UserReadDto createdObject = await _userService.CreateOne(dto);
            return CreatedAtAction("CreateOne", createdObject);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public override async Task<ActionResult<IEnumerable<UserReadDto>>> GetAll([FromQuery] QueryOptions queryOptions)
        {
            return Ok(await _userService.GetAll(queryOptions));
        }
    }
}