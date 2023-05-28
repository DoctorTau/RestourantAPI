using OrderService.Models;

namespace OrderService.Repositories
{
    /// <summary>
    /// Interface for managing dishes.
    /// </summary>
    public interface IDishRepository{
        /// <summary>
        /// Creates a new dish.
        /// </summary>
        /// <param name="dish">The dish to create.</param>
        /// <returns>The created dish.</returns>
        Task<Dish> CreateDishAsync(DishCreatingDto dish);
        
        /// <summary>
        /// Gets a dish by its ID.
        /// </summary>
        /// <param name="id">The ID of the dish to get.</param>
        /// <returns>The dish with the specified ID.</returns>
        Task<Dish> GetDishByIdAsync(int id);
        
        /// <summary>
        /// Updates an existing dish.
        /// </summary>
        /// <param name="dish">The dish to update.</param>
        /// <returns>The updated dish.</returns>
        Task<Dish> UpdateDishAsync(Dish dish);        

        /// <summary>
        /// Deletes a dish by its ID.
        /// </summary>
        /// <param name="id">The ID of the dish to delete.</param>
        /// <returns>The deleted dish.</returns>
        Task<Dish> DeleteDishAsync(int id);
    }
}