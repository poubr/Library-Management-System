using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Service.src.Dtos;

namespace LibraryManagementSystem.Service.src.Abstractions
{
    public interface IUserService : IBaseService<User, UserReadDto, UserCreateDto, UserUpdateDto>
    {
        Task<bool> CreateAdmin(Guid id);
        Task<UserReadDto> UpdatePassword(Guid id, string newPassword);    
    }
}