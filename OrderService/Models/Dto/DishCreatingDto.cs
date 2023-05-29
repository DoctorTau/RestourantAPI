namespace OrderService.Models
{
    /// <summary>
    /// Represents the data transfer object for creating a dish.
    /// </summary>
    public class DishCreatingDto
    {
        /// <summary>
        /// Gets or sets the name of the dish.
        /// </summary>
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the description of the dish.
        /// </summary>
        public string Description { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the quantity of the dish.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price of the dish.
        /// </summary>
        public int Price { get; set; }
    }
}