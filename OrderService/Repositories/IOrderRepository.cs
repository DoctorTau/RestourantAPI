using OrderService.Models;

namespace OrderService.Repositories{
    /// <summary>
    /// Interface for the Order Repository
    /// </summary>
    public interface IOrderRepository{
        /// <summary>
        /// Creates a new order asynchronously
        /// </summary>
        /// <param name="orderCreatingDto">The order creation data transfer object</param>
        /// <param name="userId">The ID of the user creating the order</param>
        /// <returns>The newly created order</returns>
        Task<Order> CreateOrderAsync(OrderCreatingDto orderCreatingDto, int userId);

        /// <summary>
        /// Gets an order by its ID asynchronously
        /// </summary>
        /// <param name="id">The ID of the order to retrieve</param>
        /// <returns>The order with the specified ID</returns>
        Task<Order> GetOrderByIdAsync(int id);

        /// <summary>
        /// Updates an order asynchronously
        /// </summary>
        /// <param name="order">The order to update</param>
        /// <returns>The updated order</returns>
        Task<Order> UpdateOrderAsync(Order order);
    }
}