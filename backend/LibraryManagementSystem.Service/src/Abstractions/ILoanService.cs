using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Domain.src.Shared;
using LibraryManagementSystem.Service.src.Dtos;

namespace LibraryManagementSystem.Service.src.Abstractions
{
    public interface ILoanService : IBaseService<Loan, LoanReadDto, LoanCreateDto, LoanUpdateDto>
    {
        Task<IEnumerable<LoanReadDto>> GetLoansByUser(Guid id, QueryOptions queryOptions);    
    }
}