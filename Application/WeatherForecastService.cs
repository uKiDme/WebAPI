using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Application;
using Domain.Entities;
using Domain.Interfaces;

namespace WebApi.Application.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public IEnumerable<WeatherForecastDto> GetWeatherForecasts()
        {
            var forecasts = _weatherForecastRepository.GetAll();

            return forecasts.Select(f => new WeatherForecastDto
            {
                Date = f.Date,
                TemperatureC = f.TemperatureC,
                TemperatureF = f.TemperatureF,
                Summary = f.Summary
            });
        }

        public async Task AddWeatherForecasts(IEnumerable<WeatherForecastDto> forecasts)
        {
            var weatherForecasts = forecasts.Select(f => new WeatherForecast
            {
                Date = f.Date,
                TemperatureC = f.TemperatureC,
                TemperatureF = (int)(f.TemperatureC * 1.8) + 32,
                Summary = f.Summary
            });

            await _weatherForecastRepository.AddRangeAsync(weatherForecasts);
        }
    }
}
