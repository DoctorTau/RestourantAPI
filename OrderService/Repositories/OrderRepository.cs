using OrderService.Database;
using OrderService.Models;
using OrderService.Services;

namespace OrderService.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IDishRepository _dishRepository;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public OrderRepository(AppDbContext dbContext,
                               IDishRepository dishRepository,
                               IServiceScopeFactory serviceScopeFactory)
        {
            _dbContext = dbContext;
            _dishRepository = dishRepository;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<Order> CreateOrderAsync(OrderCreatingDto orderCreatingDto, int userId)
        {
            Order order = new()
            {
                UserId = userId,
                SpecialRequest = orderCreatingDto.SpecialRequest
            };

            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();

            foreach (DishAddingDto dishAddingDto in orderCreatingDto.Dishes)
            {
                await AddDishToOrderAsync(order, dishAddingDto);
            }

            var orderProcessor = new OrderBackgroundService(_serviceScopeFactory, order.Id);
            _ = orderProcessor.StartAsync(CancellationToken.None);

            return order;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await _dbContext.Orders.FindAsync(id)
                ?? throw new ArgumentException("Order with this id does not exist");
            return order;
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            Order existingOrder = await GetOrderByIdAsync(order.Id);

            existingOrder.SpecialRequest = order.SpecialRequest;
            existingOrder.Status = order.Status;

            // Update the order in the database
            _dbContext.Update(existingOrder);
            await _dbContext.SaveChangesAsync();

            return existingOrder;
        }

        private async Task AddDishToOrderAsync(Order order, DishAddingDto dishAddingDto)
        {
            Dish dish = await _dishRepository.GetDishByIdAsync(dishAddingDto.DishId);

            if (dish.Quantity < dishAddingDto.Quantity)
            {
                throw new ArgumentException($"Dish with id {dish.Id} is out of stock");
            }

            var orderDish = new OrderDish
            {
                OrderId = order.Id,
                DishId = dish.Id,
                Quantity = dishAddingDto.Quantity,
                CurrentPrice = dish.Price
            };

            dish.Quantity -= dishAddingDto.Quantity;

            await _dishRepository.UpdateDishAsync(dish);

            await _dbContext.OrderDishes.AddAsync(orderDish);
            await _dbContext.SaveChangesAsync();
        }
    }
}