using Microsoft.AspNetCore.Mvc;
using WebAPI_Labs.DTO;
using WebAPI_Labs.Services.AuthService;

namespace WebAPI_Labs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            var response = await _authService.LoginAsync(request);
            if (!response.Success)
            {
                return StatusCode(response.Code, response.Message);
            }
            return Ok(response.Data.First());
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            var response = await _authService.RegisterAsync(request);
            if (!response.Success)
            {
                return StatusCode(response.Code, response.Message);
            }
            return Ok(response.Data.First());
        }
    }
}
