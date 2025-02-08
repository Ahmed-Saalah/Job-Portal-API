using JobPortal.Application.DTOs.Identity;
using JobPortal.Application.Services.Interfaces.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAuthenticationService authenticationService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerUser)
        {
            var result = await authenticationService.RegisterUser(registerUser);    
            if (result.Success)
                return Ok(result);

            return BadRequest(result);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginUser)
        {
            var result = await authenticationService.LoginUser(loginUser);  
            if (result.Success) 
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("refreshToken/{refreshToken}")]
        public async Task<IActionResult> ReviveToken(string refreshToken)
        {
            var result = await authenticationService.ReviveToken(refreshToken);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
