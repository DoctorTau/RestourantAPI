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

            StartOrderProcess(order);

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

        private async Task AddDishToOrderAsync(Order order, DishAddingDto dishAddingDto){
            Dish dish = await _dishRepository.GetDishByIdAsync(dishAddingDto.DishId);

            if(dish.Quantity == 0){
                throw new ArgumentException($"Dish with id {dish.Id} is out of stock");
            }

            var orderDish = new OrderDish{
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

        private void StartOrderProcess(Order order){
            // Start a new thread to process the order.
            // This process should wait for random time between 5 and 15 seconds.
            // After that, it should update the order status to "Processing".
            // After that, process should wait for random time between 5 and 15 seconds.
            // After that, it should update the order status to "Done".
            Thread thread = new(async () => {
                Random random = new();
                int randomTime = random.Next(5, 15);
                Thread.Sleep(randomTime * 1000);
                order.Status = OrderStatus.Processing;
                await UpdateOrderAsync(order);
                randomTime = random.Next(5, 15);
                Thread.Sleep(randomTime * 1000);
                order.Status = OrderStatus.Done;
                await UpdateOrderAsync(order);
            });

            thread.Start();
        }
    }
}