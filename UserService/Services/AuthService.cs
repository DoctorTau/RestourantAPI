using UserService.Models;

namespace UserService.Services{
    public class AuthService : IAuthService
    {
        public Task<User> LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<User> RegisterAsync(UserRegistrationDto user)
        {
            throw new NotImplementedException();
        }
    }
}