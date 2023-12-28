using Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class SpaceWeatherDbContext : DbContext
    {
        public SpaceWeatherDbContext(DbContextOptions<SpaceWeatherDbContext> options) : base(options) { }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Satellite> Satellites { get; set; }
    }
}
