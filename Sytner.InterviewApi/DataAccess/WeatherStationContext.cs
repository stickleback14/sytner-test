using Microsoft.EntityFrameworkCore;
using Sytner.Utilities.Domain;

namespace Sytner.InterviewApi.DataAccess
{
    public class WeatherStationContext : DbContext
    {
        public WeatherStationContext() { }
        public WeatherStationContext(DbContextOptions<WeatherStationContext> options) : base(options) { }

        public DbSet<Summary> Summaries { get; set; }
        public DbSet<ForecastData> Forecasts { get; set; }
        public DbSet<WeatherStations> WeatherStations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=WeatherStation;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Summary>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Above).IsRequired();
                entity.Property(e => e.Below).IsRequired();
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.CreatedDate).IsRequired();
                entity.Property(e => e.ModifiedDate);
                entity.Property(e => e.DeletedDate);
            });

            modelBuilder.Entity<WeatherStations>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Code).IsRequired();
                entity.Property(e => e.CreatedDate).IsRequired();
                entity.Property(e => e.ModifiedDate);
                entity.Property(e => e.DeletedDate);
            });

            modelBuilder.Entity<ForecastData>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.WeatherStationId).IsRequired();
                entity.Property(e => e.Temperature).IsRequired();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.CreatedDate).IsRequired();
                entity.Property(e => e.ModifiedDate);
                entity.Property(e => e.DeletedDate);
            });
        }
    }
}
