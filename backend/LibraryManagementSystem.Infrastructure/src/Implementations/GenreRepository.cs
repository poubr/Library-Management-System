using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Domain.src.RepositoryInterfaces;
using LibraryManagementSystem.Infrastructure.src.Database;

namespace LibraryManagementSystem.Infrastructure.src.Implementations
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}