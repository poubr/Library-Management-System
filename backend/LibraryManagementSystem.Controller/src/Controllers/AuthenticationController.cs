using LibraryManagementSystem.Service.src.Abstractions;
using LibraryManagementSystem.Service.src.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controller.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authentiationService)
        {
            _authenticationService = authentiationService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> VerifyCredentials([FromBody] UserAuthDto userAuthDto)
        {
            return Ok(await _authenticationService.VerifyCredentials(userAuthDto));
        }
    }
}