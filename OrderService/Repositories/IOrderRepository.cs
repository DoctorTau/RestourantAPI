using OrderService.Models;

namespace OrderService.Repositories{
    public interface IOrderRepository{
        Task<Order> CreateOrderAsync(OrderCreatingDto orderCreatingDto, int userId);
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> UpdateOrderAsync(Order order);
    }
}