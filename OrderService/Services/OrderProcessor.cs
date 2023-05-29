using OrderService.Models;
using OrderService.Repositories;

namespace OrderService.Services
{

    /// <summary>
    /// Background service for processing orders asynchronously.
    /// </summary>
    public class OrderBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly int _orderId;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderBackgroundService"/> class.
        /// </summary>
        /// <param name="serviceScopeFactory">The service scope factory.</param>
        /// <param name="orderId">The order identifier.</param>
        public OrderBackgroundService(IServiceScopeFactory serviceScopeFactory, int orderId)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _orderId = orderId;
        }

        /// <summary>
        /// Executes the background service asynchronously.
        /// </summary>
        /// <param name="stoppingToken">The stopping token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
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
