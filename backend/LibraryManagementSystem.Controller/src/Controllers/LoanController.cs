using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Domain.src.Shared;
using LibraryManagementSystem.Service.src.Abstractions;
using LibraryManagementSystem.Service.src.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace LibraryManagementSystem.Controller.src.Controllers
{
    [Authorize]
    public class LoanController : LibraryBaseController<Loan, LoanReadDto, LoanCreateDto, LoanUpdateDto>
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService baseService) : base(baseService)
        {
            _loanService = baseService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("userloans/{id:guid}")]
        public async Task<ActionResult<IEnumerable<LoanReadDto>>> GetLoansByUser([FromQuery]Guid id, QueryOptions queryOptions)
        {
            return Ok(await _loanService.GetLoansByUser(id, queryOptions));
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{id:guid}")]
        public override async Task<ActionResult<LoanReadDto>> UpdateOne([FromRoute] Guid id, [FromBody] LoanUpdateDto updateDto)
        {
            LoanReadDto updatedEntity = await _loanService.UpdateOne(id, updateDto);
            return Ok(updatedEntity);
        }
    }
}