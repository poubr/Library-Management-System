using AutoMapper;
using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Domain.src.RepositoryInterfaces;
using LibraryManagementSystem.Domain.src.Shared;
using LibraryManagementSystem.Service.src.Abstractions;
using LibraryManagementSystem.Service.src.Dtos;

namespace LibraryManagementSystem.Service.src.Implementations
{
    public class LoanService : BaseService<Loan, LoanReadDto, LoanCreateDto, LoanUpdateDto>, ILoanService
    {
        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository, IMapper mapper): base(loanRepository, mapper)
        {
            _loanRepository = loanRepository;
        }

        public async Task<IEnumerable<LoanReadDto>> GetLoansByUser(Guid id, QueryOptions queryOptions)
        {
            IEnumerable<Loan> userLoans = await _loanRepository.GetLoansByUser(id, queryOptions);
            return _mapper.Map<IEnumerable<LoanReadDto>>(userLoans);
        }
    }
}