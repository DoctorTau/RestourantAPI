using UserService.Models;

namespace UserService.Services
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(UserRegistrationDto user);
        Task<User> LoginAsync(string email, string password);
    }
}