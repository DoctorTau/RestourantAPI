using UserService.Models;

namespace UserService.Services
{
    /// <summary>
    /// Interface for managing users.
    /// </summary>
    public interface IUserRepo{
        /// <summary>
        /// Get a user by their id
        /// </summary>
        /// <param name="id"> Id of user to get.</param>
        /// <returns> User with given id.</returns>
        Task<User> GetUserByIdAsync(int id);

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="user"> User to update.</param>
        /// <returns> Updated user.</returns>
        Task<User> UpdateUserAsync(User user);

        /// <summary>
        /// Delete a user by their id
        /// </summary>
        /// <param name="id"> Id of user to delete.</param>
        /// <returns> Deleted user.</returns>
        Task<User> DeleteUserAsync(int id);

        /// <summary>
        /// Create a manager user
        /// </summary>
        /// <param name="userCreatingDto"> UserRegistrationDto object containing information about the user to create.</param>
        /// <returns> Created manager user.</returns>
        Task<User> CreateManagerAsync(UserRegistrationDto userCreatingDto);
    }
}

