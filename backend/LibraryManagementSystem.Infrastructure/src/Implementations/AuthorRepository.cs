using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Domain.src.RepositoryInterfaces;
using LibraryManagementSystem.Infrastructure.src.Database;

namespace LibraryManagementSystem.Infrastructure.src.Implementations
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}