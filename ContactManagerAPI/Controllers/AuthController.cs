using Microsoft.AspNetCore.Mvc;
using ContactManagerAPI.Models;
using ContactManagerAPI.Services;

namespace ContactManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenGenerator _tokenGenerator;

        public AuthController(JwtTokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            // Validate the user (this should be done using a service in a real application)
            if (user.Username == "test" && user.Password == "password")
            {
                var token = _tokenGenerator.GenerateToken(user.Username);
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }
    }
}
