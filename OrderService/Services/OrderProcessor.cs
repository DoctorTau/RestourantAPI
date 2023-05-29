using OrderService.Models;
using OrderService.Repositories;

namespace OrderService.Services
{
    public class OrderBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly int _orderId;

        public OrderBackgroundService(IServiceScopeFactory serviceScopeFactory, int orderId)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _orderId = orderId;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(new Random().Next(5000, 15000), stoppingToken);

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var orderRepository = scope.ServiceProvider.GetRequiredService<IOrderRepository>();
                var order = await orderRepository.GetOrderByIdAsync(_orderId);
                order.Status = OrderStatus.Processing;
                await orderRepository.UpdateOrderAsync(order);
            }

            await Task.Delay(new Random().Next(5000, 15000), stoppingToken);

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var orderRepository = scope.ServiceProvider.GetRequiredService<IOrderRepository>();
                var order = await orderRepository.GetOrderByIdAsync(_orderId);
                order.Status = OrderStatus.Done;
                await orderRepository.UpdateOrderAsync(order);
            }
        }
    }
}