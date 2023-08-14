using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Service.src.Dtos;
using LibraryManagementSystem.Service.src.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPatch("createadmin/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<bool>> CreateAdmin([FromRoute]Guid id)
        {
            return Ok(await _userService.CreateAdmin(id));
        }

        [HttpPatch("updatepassword/{id}:Guid")]
        public async Task<ActionResult<UserReadDto>> UpdatePassword([FromRoute] Guid id, [FromBody] string newPassword)
        {
            return Ok(await _userService.UpdatePassword(id, newPassword));
        }

    }
}