namespace OrderService.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}