namespace UserService.Models
{
    /// <summary>
    /// Represents a user session.
    /// </summary>
    public class Session
    {
        /// <summary>
        /// The unique identifier of the session.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The unique identifier of the user associated with the session.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The session token used to authenticate the user.
        /// </summary>
        public string SessionToken { get; set; } = String.Empty;

        /// <summary>
        /// The date and time when the session expires.
        /// </summary>
        public DateTime ExpiresAt { get; set; }
    }
}