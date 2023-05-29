namespace OrderService.Models
{
    /// <summary>
    /// Represents a dish in the menu.
    /// </summary>
    public class Dish
    {
        /// <summary>
        /// The unique identifier of the dish.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the dish.
        /// </summary>
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// The description of the dish.
        /// </summary>
        public string Description { get; set; } = String.Empty;

        /// <summary>
        /// The price of the dish.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The quantity of the dish.
        /// </summary>
        public int Quantity { get; set; }
    }
}