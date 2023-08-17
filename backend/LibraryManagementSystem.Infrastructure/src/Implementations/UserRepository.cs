using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Domain.src.RepositoryInterfaces;
using LibraryManagementSystem.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;

namespace LibraryManagementSystem.Infrastructure.src.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DbSet<User> _users;
        private readonly DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
            _users = databaseContext.Users;
            _databaseContext = databaseContext;
        }

        public async Task<User> CreateAdmin(User user)
        {
            user.Roles = Roles.Admin;
            await _users.AddAsync(user);
            return user;
        }

        public async Task<User> UpdatePassword(User user)
        {
            _users.Update(user);
            await _databaseContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> VerifyCredentials(string email, string password)
        {
            var foundUser = await _users.FirstOrDefaultAsync(user => user.Email == email);
            if (foundUser != null && BCryptNet.Verify(password, foundUser.Password))
            {
                return foundUser;
            }
            else
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }
        }
    }
}