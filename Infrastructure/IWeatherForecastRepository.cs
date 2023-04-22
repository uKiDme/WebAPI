using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface IWeatherForecastRepository
    {
        Task AddRangeAsync(IEnumerable<WeatherForecast> forecasts);
        IEnumerable<WeatherForecast> GetAll();
        Task<int> SaveChangesAsync();
    }
}
