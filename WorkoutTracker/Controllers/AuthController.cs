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
        private readonly IJwtGenerator _jwtGenerator;

        public AuthController(IAuthService authService, IJwtGenerator jwtGenerator)
        {
            _authService = authService;
            _jwtGenerator = jwtGenerator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterRequest request)
        {
            var createdUser = await _authService.RegisterUserAsync(request);
            
            return CreatedAtAction(
                nameof(RegisterUser),
                new { id = createdUser.userId }, 
                createdUser);
        }
    }
}
