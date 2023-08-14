using LibraryManagementSystem.Service.src.Dtos;

namespace LibraryManagementSystem.Service.src.Abstractions
{
    public interface IAuthenticationService
    {
        Task<string> VerifyCredentials(UserAuthDto userAuthDto);
    }
} 