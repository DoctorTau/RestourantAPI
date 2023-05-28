using UserService.Database;
using UserService.Models;

namespace UserService.Services{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _dbContext;

        public UserRepo(AppDbContext dbContext){
            _dbContext = dbContext;
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            User user = await GetUserByIdAsync(id);
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            User? user = await _dbContext.Users.FindAsync(id)
                         ?? throw new ArgumentException("User with this id does not exist");
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            User existingUser = await GetUserByIdAsync(user.Id);

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.PasswordHash = user.PasswordHash;

            // Update the user in the database
            _dbContext.Update(existingUser);
            await _dbContext.SaveChangesAsync();

            return existingUser;
        }
    }
}