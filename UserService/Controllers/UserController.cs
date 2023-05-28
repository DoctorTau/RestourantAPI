using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using UserService.Services;

namespace UserService.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    /// <summary>
    /// Controller for user-related actions
    /// </summary>
    public class UserController : ControllerBase{
        private readonly IAuthService _authService;
        private readonly IUserRepo _userService;

        /// <summary>
        /// Constructor for UserController
        /// </summary>
        /// <param name="authService">The authentication service</param>
        /// <param name="userService">The user service</param>
        public UserController(IAuthService authService, IUserRepo userService){
            _authService = authService;
            _userService = userService;
        }

        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="userRegistrationDto">The user registration data</param>
        /// <returns>The newly registered user</returns>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(UserRegistrationDto userRegistrationDto){
            var user = await _authService.RegisterAsync(userRegistrationDto);
            return Ok(user);
        }

        /// <summary>
        /// Logs in a user
        /// </summary>
        /// <param name="email">The user's email</param>
        /// <param name="password">The user's password</param>
        /// <returns>The user's session</returns>
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(string email, string password){
            var session = await _authService.LoginAsync(email, password);
            return Ok(session);
        }

        /// <summary>
        /// Gets the current user's information
        /// </summary>
        /// <returns>The current user's information</returns>
        [HttpGet("me"), Authorize]
        public async Task<IActionResult> GetMeAsync(){
            // Get the user id from the claims
            int userId = int.Parse(User.Claims.First(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value);
            var user = await _userService.GetUserByIdAsync(userId);
            return Ok(user);
        }
    }
}