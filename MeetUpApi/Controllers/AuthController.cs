using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;

namespace API.Controllers
{
    [Route("MeetUpApi")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterUserDto request)
        {
            var result = await _userService.CreateUserAsync(request);
            return Ok(request);
        }

        [HttpPost("login")]
        public async Task<ActionResult> LogIn(LoginUserDto request)
        {
            Tuple<User, bool> result = await _userService.VerifyPasswordAsync(request);
            if (result.Item2)
            {
                string token = await _userService.CreateTokenAsync(result.Item1);
                return Ok(token);
            }
            return BadRequest("Incorrect password or user not found.");
        }
    }
}
