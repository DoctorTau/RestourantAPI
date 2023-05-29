using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Database
{
    /// <summary>
    /// Represents the database context for the application.
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
        /// Configures the database connection options.
        /// </summary>
        /// <param name="optionsBuilder">The options builder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }

        /// <summary>
        /// Gets or sets the users table.
        /// </summary>
        public required DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the sessions table.
        /// </summary>
        public required DbSet<Session> Sessions { get; set; }
    }
}