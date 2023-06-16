using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Application;

namespace WebApi.Application
{
    public interface IWeatherForecastService
    {
        // Get a collection of weather forecasts
        IEnumerable<WeatherForecastDto> GetWeatherForecasts();

        // Add weather forecasts to the system
        Task AddWeatherForecasts(IEnumerable<WeatherForecastDto> forecasts);

        // Get an external weather forecast based on latitude and longitude
        Task<string?> GetExternalWeatherForecast(double latitude, double longitude);
    }
}
