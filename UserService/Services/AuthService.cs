using UserService.Database;
using UserService.Models;

namespace UserService.Services{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public Task<User> LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<User> RegisterAsync(UserRegistrationDto user)
        {
            // Check if user with this username or email already exists
            var existingUser = await _context.Users.FindAsync(user.Email, user.Name);
            if (existingUser != null)
            {
                throw new ArgumentException("User with this email or username already exists");
            }

            // Hash the password using BCrypt
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);

            // Create a new user
            var newUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                PasswordHash = passwordHash
            };

            // Add the user to the database
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }
    }
}