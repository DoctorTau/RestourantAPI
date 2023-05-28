namespace UserService.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string PasswordHash { get; set; } = String.Empty;
        public UserRole Role { get; set; } = UserRole.User; 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow.ToUniversalTime();
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow.ToUniversalTime();
    }
}