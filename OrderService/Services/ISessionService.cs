using UserService.Models;

namespace UserService.Services{

    /// <summary>
    /// Interface for managing user sessions.
    /// </summary>
    public interface ISessionService
    {
        /// <summary>
        /// Creates a new session for the specified user.
        /// </summary>
        /// <param name="user">The user to create a session for.</param>
        /// <returns>The newly created session.</returns>
        Task<Session> CreateSession(User user);
    }
}