using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using UserService.Services;

namespace UserService.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase{
        private readonly IAuthService _authService;
        private readonly IUserRepo _userService;
        public UserController(IAuthService authService, IUserRepo userService){
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(UserRegistrationDto userRegistrationDto){
            var user = await _authService.RegisterAsync(userRegistrationDto);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(string email, string password){
            var session = await _authService.LoginAsync(email, password);
            return Ok(session);
        }

        [HttpGet("me"), Authorize]
        public async Task<IActionResult> GetMeAsync(){
            // Get the user id from the claims
            int userId = int.Parse(User.Claims.First(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value);
            var user = await _userService.GetUserByIdAsync(userId);
            return Ok(user);
        }
    }
}