using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Application.DTOs.Requests;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Application.Security_Interface;

namespace WorkoutTracker.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterRequest request)
        {
            var register = await _authService.RegisterUserAsync(request);
            
            return CreatedAtAction(
                nameof(RegisterUser),
                new { id = register.userId }, 
                register);
        }

        [HttpGet("login")]
        public async Task<IActionResult> LoginUser(LoginRequest request)
        {
            var login = await _authService.LoginUserAsync(request);

            return Ok(login);
        }
    }
}
