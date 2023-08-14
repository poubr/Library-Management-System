using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Domain.src.Shared;
using LibraryManagementSystem.Service.src.Abstractions;
using LibraryManagementSystem.Service.src.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// for some reason the Loan schema is missing in swagger documentation
// and I've no idea why?

namespace LibraryManagementSystem.Controller.src.Controllers
{
    public class LoanController : LibraryBaseController<Loan, LoanReadDto, LoanCreateDto, LoanUpdateDto>
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService baseService) : base(baseService)
        {
            _loanService = baseService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("userloans/{id}:Guid")]
        public async Task<ActionResult<IEnumerable<LoanReadDto>>> GetLoansByUser([FromQuery]Guid id, QueryOptions queryOptions)
        {
            return Ok(await _loanService.GetLoansByUser(id, queryOptions));
        }
    }
}