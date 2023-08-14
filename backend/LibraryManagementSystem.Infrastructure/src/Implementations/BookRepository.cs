using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Domain.src.RepositoryInterfaces;
using LibraryManagementSystem.Infrastructure.src.Database;

namespace LibraryManagementSystem.Infrastructure.src.Implementations
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}