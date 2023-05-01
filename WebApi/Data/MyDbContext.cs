using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<WeatherForecastModel> WeatherForecasts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=MyDatabase;User Id=sa;Password=yourStrong(!)Password;TrustServerCertificate=true;");
        }
    }
}
