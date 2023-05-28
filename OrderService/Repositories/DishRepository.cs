using OrderService.Database;
using OrderService.Models;

namespace OrderService.Repositories{
    public class DishRepository : IDishRepository
    {
        AppDbContext _context;
        public DishRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Dish> CreateDishAsync(DishCreatingDto dish)
        {
            // Check if the dish already exists.
            var existingDish = _context.Dishes.FirstOrDefault(d => d.Name == dish.Name);
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
            await _context.Dishes.AddAsync(newDish);
            await _context.SaveChangesAsync();

            return newDish;
        }

        public async Task<Dish> DeleteDishAsync(int id)
        {
            var dish = GetDishById(id);
            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();
            return dish;
        }

        public Dish GetDishById(int id)
        {
            var dish = _context.Dishes.FirstOrDefault(d => d.Id == id);
            if (dish == null)
            {
                throw new ArgumentException($"Dish with ID {id} does not exist.");
            }

            return dish;
        }

        public async Task<Dish> UpdateDishAsync(Dish dish)
        {
            Dish existingDish = GetDishById(dish.Id);
            existingDish.Name = dish.Name;
            existingDish.Description = dish.Description;
            existingDish.Price = dish.Price;
            existingDish.Quantity = dish.Quantity;
            _context.Dishes.Update(existingDish);
            await _context.SaveChangesAsync();
            return existingDish;
        }
    }
}