namespace OrderService.Models
{
    /// <summary>
    /// Represents a dish in an order.
    /// </summary>
    public class OrderDish
    {
        /// <summary>
        /// The unique identifier of the order dish.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The unique identifier of the order that this dish belongs to.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// The unique identifier of the dish.
        /// </summary>
        public int DishId { get; set; }

        /// <summary>
        /// The quantity of this dish in the order.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The current price of this dish.
        /// </summary>
        public decimal CurrentPrice { get; set; }
    }
}