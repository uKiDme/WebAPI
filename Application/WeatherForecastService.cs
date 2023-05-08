using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Application;
using Domain.Entities;
using Infrastructure.Repositories;
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
            var weatherForecasts = forecasts.Select(f =>
            {
                int temperatureC = Random.Shared.Next(0, 43); 
                int temperatureF = (int)(temperatureC * 1.8) + 32; 
                string summary;
                if (temperatureC <= 10)
                {
                    summary = "Very Cold";
                }
                else if (temperatureC <= 20)
                {
                    summary = "Cold";
                }
                else if (temperatureC <= 30)
                {
                    summary = "Warm";
                }
                else
                {
                    summary = "Hot";
                }

                return new WeatherForecast
                {
                    Date = DateTime.Now, 
                    TemperatureC = temperatureC,
                    TemperatureF = temperatureF,
                    Summary = summary
                };
            });

            await _weatherForecastRepository.AddRangeAsync(weatherForecasts);
            await _weatherForecastRepository.SaveChangesAsync();
        }

    }
}
