using OrderService.Database;
using OrderService.Models;

namespace OrderService.Repositories{
    public class DishRepository : IDishRepository
    {
        private readonly AppDbContext _context;
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
            var dish = await GetDishByIdAsync(id);
            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();
            return dish;
        }

        public async Task<Dish> GetDishByIdAsync(int id)
        {
            var dish = await _context.Dishes.FindAsync(id)
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
            _context.Dishes.Update(existingDish);
            await _context.SaveChangesAsync();
            return existingDish;
        }
    }
}