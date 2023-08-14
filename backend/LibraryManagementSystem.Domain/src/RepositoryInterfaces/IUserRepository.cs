using LibraryManagementSystem.Domain.src.Entities;

namespace LibraryManagementSystem.Domain.src.RepositoryInterfaces
{
    public interface IUserRepository: IBaseRepository<User>
    {
        Task<User> CreateAdmin(User user);
        Task<User> UpdatePassword(User user);
        Task<User> VerifyCredentials (String email, String password); 
    }
}