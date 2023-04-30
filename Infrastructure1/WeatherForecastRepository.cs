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
        private readonly IMyDbContext _dbContext;

        public WeatherForecastRepository(IMyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddRangeAsync(IEnumerable<WeatherForecast> forecasts)
        {
            await _dbContext.WeatherForecasts.AddRangeAsync(forecasts);
        }

        public IEnumerable<WeatherForecast> GetAll()
        {
            return _dbContext.WeatherForecasts;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
