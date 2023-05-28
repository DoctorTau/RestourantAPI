namespace OrderService.Models{
    public class DishCreatingDto{
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}