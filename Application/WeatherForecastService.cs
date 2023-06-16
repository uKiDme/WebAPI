using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Application;
using Domain.Entities;
using Infrastructure.Repositories;
using Infrastructure.ExternalApis;
using AutoMapper;

namespace WebApi.Application.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        private readonly OpenMeteoApiClient _openMeteoApiClient;
        private readonly IMapper _mapper;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository, OpenMeteoApiClient openMeteoApiClient, IMapper mapper)
        {
            _weatherForecastRepository = weatherForecastRepository;
            _openMeteoApiClient = openMeteoApiClient;
            _mapper = mapper;
        }

        // Retrieves weather forecasts from the repository and maps them to DTOs
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

        // Adds weather forecasts to the repository
        public async Task AddWeatherForecasts(IEnumerable<WeatherForecastDto> forecasts)
        {
            var weatherForecasts = forecasts.Select(f =>
            {
                // Generate random temperature values and determine summary based on temperature
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

        // Retrieves external weather forecast using OpenMeteo API based on latitude and longitude
        public async Task<string?> GetExternalWeatherForecast(double latitude, double longitude)
        {
            // Calls OpenMeteoApiClient to get the weather forecast data as a dictionary
            Dictionary<string, object>? forecastData = await _openMeteoApiClient.GetWeatherForecast(latitude, longitude);

            if (forecastData != null)
            {
                // Extracts the current weather information from the forecastData dictionary
                if (forecastData.TryGetValue("current_weather", out object? currentWeatherObject) && currentWeatherObject is Dictionary<string, object> currentWeather)
                {
                    // Extracts the forecast time string from the currentWeather dictionary
                    if (currentWeather.TryGetValue("time", out object? forecastTime) && forecastTime is string forecastTimeString)
                    {
                        // Returns the forecast time string
                        return forecastTimeString;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        // Maps forecastData dictionary to MeteoApiForecastDto using AutoMapper
        public MeteoApiForecastDto MapToMeteoApiForecastDto(Dictionary<string, object> forecastData)
        {
            var forecastDto = _mapper.Map<MeteoApiForecastDto>(forecastData);
            return forecastDto;
        }
    }
}
