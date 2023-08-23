using Microsoft.EntityFrameworkCore;
using WebAPI_Labs.Models;

namespace WebAPI_Labs.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        private readonly IConfiguration _configuration;

        public ApplicationContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("base"));
        }
    }
}
