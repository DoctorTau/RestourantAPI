using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService.Database{
    public class AppDbContext : DbContext{
        private readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration) {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }

        public required DbSet<Order> Orders { get; set; }
        public required DbSet<Dish> Dishes { get; set; }
        public required DbSet<OrderDish> OrderDishes { get; set; }
   }
}