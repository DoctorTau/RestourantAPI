namespace OrderService.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string SpecialRequest { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow.ToUniversalTime();
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow.ToUniversalTime();
    }
}