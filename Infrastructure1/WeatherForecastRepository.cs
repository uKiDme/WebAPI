using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly MyDbContext _dbContext;

        public WeatherForecastRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddRangeAsync(IEnumerable<WeatherForecast> forecasts)
        {
            // Add a range of weather forecasts to the DbContext asynchronously
            await _dbContext.WeatherForecasts.AddRangeAsync(forecasts);
        }

        public IEnumerable<WeatherForecast> GetAll()
        {
            // Retrieve all weather forecasts from the DbContext
            return _dbContext.WeatherForecasts;
        }

        public async Task<int> SaveChangesAsync()
        {
            // Save changes made in the DbContext asynchronously
            return await _dbContext.SaveChangesAsync();
        }
    }
}

