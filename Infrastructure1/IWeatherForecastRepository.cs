using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface IWeatherForecastRepository
    {
        // Add a range of weather forecasts asynchronously
        Task AddRangeAsync(IEnumerable<WeatherForecast> forecasts);

        // Get all weather forecasts
        IEnumerable<WeatherForecast> GetAll();

        // Save changes to the underlying data store asynchronously
        Task<int> SaveChangesAsync();
    }
}
