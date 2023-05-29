namespace OrderService.Models
{
    /// <summary>
    /// Represents an order made by a user.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// The unique identifier for the order.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The unique identifier for the user who made the order.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The current status of the order.
        /// </summary>
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        /// <summary>
        /// Any special requests made by the user for the order.
        /// </summary>
        public string SpecialRequest { get; set; } = String.Empty;

        /// <summary>
        /// The date and time when the order was created.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow.ToUniversalTime();

        /// <summary>
        /// The date and time when the order was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow.ToUniversalTime();
    }
}