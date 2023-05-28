using Microsoft.EntityFrameworkCore;
using OrderService.Database;
using OrderService.Models;

namespace OrderService.Repositories{
    public class DishRepository : IDishRepository
    {
        private readonly AppDbContext _dbContext;
        public DishRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Dish>> GetAllDishesAsync()
        {
            return await _dbContext.Dishes.ToListAsync();
        }

        public async Task<IEnumerable<Dish>> GetAllPossibleDishesAsync(){
            var allDishes = await GetAllDishesAsync();
            return allDishes.Where(d => d.Quantity > 0); 
        }

        public async Task<Dish> CreateDishAsync(DishCreatingDto dish)
        {
            // Check if the dish already exists.
            var existingDish = _dbContext.Dishes.FirstOrDefault(d => d.Name == dish.Name);
            if (existingDish == null || existingDish.Name == dish.Name)
            {
                throw new ArgumentException($"Dish with name {dish.Name} already exists.");
            }

            // Create the dish.
            var newDish = new Dish
            {
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                Quantity = dish.Quantity
            };

            // Add the dish to the database.
            await _dbContext.Dishes.AddAsync(newDish);
            await _dbContext.SaveChangesAsync();

            return newDish;
        }

        public async Task<Dish> DeleteDishAsync(int id)
        {
            var dish = await GetDishByIdAsync(id);
            _dbContext.Dishes.Remove(dish);
            await _dbContext.SaveChangesAsync();
            return dish;
        }

        public async Task<Dish> GetDishByIdAsync(int id)
        {
            var dish = await _dbContext.Dishes.FindAsync(id)
                ?? throw new ArgumentException("Dish with this id does not exist");
            return dish;
        }

        public async Task<Dish> UpdateDishAsync(Dish dish)
        {
            Dish existingDish = await GetDishByIdAsync(dish.Id);
            existingDish.Name = dish.Name;
            existingDish.Description = dish.Description;
            existingDish.Price = dish.Price;
            existingDish.Quantity = dish.Quantity;
            _dbContext.Dishes.Update(existingDish);
            await _dbContext.SaveChangesAsync();
            return existingDish;
        }
    }
}