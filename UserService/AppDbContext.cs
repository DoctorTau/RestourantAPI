using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Database{
    public class AppDbContext : DbContext{
        private readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration) {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }

        public required DbSet<User> Users { get; set; }
        public required DbSet<Session> Sessions { get; set; }
    }
}