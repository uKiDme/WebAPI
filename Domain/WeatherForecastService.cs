using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Domain Layer

namespace Domain.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _repository;

        public WeatherForecastService(IWeatherForecastRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<WeatherForecastDto>> GetWeatherForecastsAsync()
        {
            var forecasts = await _repository.GetWeatherForecastsAsync();
            return forecasts.Select(x => new WeatherForecastDto
            {
                Date = x.Date,
                TemperatureC = x.TemperatureC,
                TemperatureF = x.TemperatureF,
                Summary = x.Summary
            });
        }

        public async Task AddWeatherForecastsAsync(IEnumerable<WeatherForecastDto> forecasts)
        {
            var entities = forecasts.Select(x => new WeatherForecast
            {
                Date = x.Date,
                TemperatureC = x.TemperatureC,
                Summary = x.Summary
            });
            await _repository.AddWeatherForecastsAsync(entities);
        }
    }
}
