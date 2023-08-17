using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Service.src.Abstractions;
using LibraryManagementSystem.Service.src.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagementSystem.Controller.src.Controllers
{
    [Authorize(Roles = "Admin")] 
    public class AuthorController : LibraryBaseController<Author, AuthorReadDto, AuthorCreateDto, AuthorUpdateDto>
    {
        public AuthorController(IAuthorService baseService) : base(baseService)
        {
        }
    }
}