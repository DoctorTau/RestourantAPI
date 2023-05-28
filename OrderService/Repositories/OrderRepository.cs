using OrderService.Database;
using OrderService.Models;

namespace OrderService.Repositories{
    public class OrderRepository : IOrderRepository{
        private readonly AppDbContext _dbContext;
        private readonly IDishRepository _dishRepository;

        public OrderRepository(AppDbContext dbContext, IDishRepository dishRepository){
            _dbContext = dbContext;
            _dishRepository = dishRepository;
        }

        public async Task<Order> CreateOrderAsync(OrderCreatingDto orderCreatingDto)
        {
            Order order = new()
            {
                UserId = orderCreatingDto.UserId,
                SpecialRequest = orderCreatingDto.SpecialRequest
            };

            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();

            foreach(DishAddingDto dishAddingDto in orderCreatingDto.Dishes){
                await AddDishToOrderAsync(order, dishAddingDto);
            }

            return order;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await _dbContext.Orders.FindAsync(id)
                ?? throw new ArgumentException("Order with this id does not exist");
            return order;
        }

        private async Task AddDishToOrderAsync(Order order, DishAddingDto dishAddingDto){
            Dish dish = await _dishRepository.GetDishByIdAsync(dishAddingDto.DishId);

            var orderDish = new OrderDish{
                OrderId = order.Id,
                DishId = dish.Id,
                Quantity = dishAddingDto.Quantity,
                CurrentPrice = dish.Price
            };
            await _dbContext.OrderDishes.AddAsync(orderDish);
            await _dbContext.SaveChangesAsync();
        }
    }
}