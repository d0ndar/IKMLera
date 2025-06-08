using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration _Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Organizers> Organizers { get; set; }
        public DbSet<LocationEvent> LocationEvents { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Events> Events { get; set; }
        
    }
}
