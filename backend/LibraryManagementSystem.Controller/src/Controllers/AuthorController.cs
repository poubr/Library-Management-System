using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Service.src.Abstractions;
using LibraryManagementSystem.Service.src.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagementSystem.Controller.src.Controllers
{
    // going by Helmet (and Helda) which both only display author's name as part of book info
    // but do not allow users to see the author collections or ifno
    [Authorize(Roles = "Admin")] 
    public class AuthorController : LibraryBaseController<Author, AuthorReadDto, AuthorCreateDto, AuthorUpdateDto>
    {
        public AuthorController(IAuthorService baseService) : base(baseService)
        {
        }
    }
}