using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Domain.src.RepositoryInterfaces;
using LibraryManagementSystem.Domain.src.Shared;
using LibraryManagementSystem.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Infrastructure.src.Implementations
{
    public class LoanRepository : BaseRepository<Loan>, ILoanRepository
    {
        private readonly DbSet<Loan> _loans;
        private readonly DatabaseContext _databaseContext;
        
        public LoanRepository(DatabaseContext databaseContext) : base (databaseContext)
        {
            _loans = databaseContext.Loans;
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Loan>> GetLoansByUser(Guid id, QueryOptions queryOptions)
        {   
            // TODO if time: implement other query options
            // (possibly set different filter for loans?)
            int skip = (queryOptions.PageNumber - 1) * queryOptions.PageSize;
            var query = _loans.AsQueryable();
            query = query.Skip(skip).Take(queryOptions.PageSize).Where(loan => loan.User.Id == id);
            return await query.ToListAsync();
        }
    }
}