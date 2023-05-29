using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService.Database
{
    /// <summary>
    /// Represents the database context for the OrderService application.
    /// </summary>
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Configures the database connection options for the context.
        /// </summary>
        /// <param name="optionsBuilder">The options builder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }

        /// <summary>
        /// Gets or sets the orders in the database.
        /// </summary>
        public required DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets the dishes in the database.
        /// </summary>
        public required DbSet<Dish> Dishes { get; set; }

        /// <summary>
        /// Gets or sets the order dishes in the database.
        /// </summary>
        public required DbSet<OrderDish> OrderDishes { get; set; }
    }
}