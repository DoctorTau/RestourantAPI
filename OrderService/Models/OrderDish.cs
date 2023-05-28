namespace OrderService.Models{
    public class OrderDish{
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int DishId { get; set; }
        public int Quantity { get; set; }
        public int CurrentPrice { get; set; }
    }
}