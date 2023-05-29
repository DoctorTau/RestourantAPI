namespace UserService.Models
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class User
    {
        /// <summary>
        /// The unique identifier for the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the user.
        /// </summary>
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// The email address of the user.
        /// </summary>
        public string Email { get; set; } = String.Empty;

        /// <summary>
        /// The hashed password of the user.
        /// </summary>
        public string PasswordHash { get; set; } = String.Empty;

        /// <summary>
        /// The role of the user.
        /// </summary>
        public UserRole Role { get; set; } = UserRole.User;

        /// <summary>
        /// The date and time the user was created.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow.ToUniversalTime();

        /// <summary>
        /// The date and time the user was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow.ToUniversalTime();
    }
}