namespace OrderService.Models{
    public class DishAddingDto{
        public int DishId { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderCreatingDto{
        public int UserId { get; set; }
        public List<DishAddingDto> Dishes { get; set; } = new List<DishAddingDto>();
        public string SpecialRequest { get; set; } = String.Empty;
    }
}