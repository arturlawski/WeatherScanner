namespace Weather.Persistance
{
    using global::WeatherSofomo.Domain;
    using Microsoft.EntityFrameworkCore;

    namespace WeatherSofomo.Persistence
    {
        public class WeatherDbContext : DbContext
        {
            public DbSet<WeatherEntity> WeatherEntities { get; set; }

            public WeatherDbContext(DbContextOptions<WeatherDbContext> options)
                : base(options)
            {
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }
        }
    }
}
