using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Application;
using Domain.Entities;
using Infrastructure.Repositories;
using Infrastructure.ExternalApis;

namespace WebApi.Application.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        private readonly OpenMeteoApiClient _openMeteoApiClient;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository,OpenMeteoApiClient openMeteoApiClient)
        {
            _weatherForecastRepository = weatherForecastRepository;
            _openMeteoApiClient = openMeteoApiClient;
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
        public async Task<string?> GetExternalWeatherForecast(double latitude, double longitude)
        {
            // testing manual values
            string? forecast = await _openMeteoApiClient.GetWeatherForecast(38.020258, 23.692641);
            return forecast;
        }
    }
}
