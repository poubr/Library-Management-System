using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Service.src.Dtos;

namespace LibraryManagementSystem.Service.src.Abstractions
{
    public interface IAuthorService : IBaseService<Author, AuthorReadDto, AuthorCreateDto, AuthorUpdateDto>
    {
        
    }
}