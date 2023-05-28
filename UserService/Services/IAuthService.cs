using UserService.Models;

namespace UserService.Services
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(UserRegistrationDto user);
        Task<Session> LoginAsync(string email, string password);
    }
}