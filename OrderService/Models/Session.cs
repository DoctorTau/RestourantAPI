namespace UserService.Models
{
    public class Session
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SessionToken { get; set; } = String.Empty;
        public DateTime ExpiresAt { get; set; }
    }
}