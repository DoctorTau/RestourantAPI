using UserService.Models;

namespace UserService.Services
{
    /// <summary>
    /// Interface for authentication service.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="user">The user to register.</param>
        /// <returns>The registered user.</returns>
        Task<User> RegisterAsync(UserRegistrationDto user);

        /// <summary>
        /// Logs in a user.
        /// </summary>
        /// <param name="email">The email of the user to log in.</param>
        /// <param name="password">The password of the user to log in.</param>
        /// <returns>The session of the logged in user.</returns>
        Task<Session> LoginAsync(string email, string password);
    }
}