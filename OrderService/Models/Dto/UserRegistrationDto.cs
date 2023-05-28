using System.ComponentModel.DataAnnotations;

namespace UserService.Models{
    public class UserRegistrationDto{
        [Required, MinLength(3), MaxLength(32)]
        public string Name { get; set; } = String.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = String.Empty;
        [Required, MinLength(6), MaxLength(32)]
        public string Password { get; set; } = String.Empty;
    }
}