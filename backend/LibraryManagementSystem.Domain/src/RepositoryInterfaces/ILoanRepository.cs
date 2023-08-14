using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Domain.src.Shared;

namespace LibraryManagementSystem.Domain.src.RepositoryInterfaces
{
    public interface ILoanRepository : IBaseRepository<Loan>
    {
        Task<IEnumerable<Loan>> GetLoansByUser(Guid id, QueryOptions queryOptions);
    }
}