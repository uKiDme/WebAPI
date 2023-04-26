using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Application;

namespace WebApi.Application
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecastDto> GetWeatherForecasts();
        Task AddWeatherForecasts(IEnumerable<WeatherForecastDto> forecasts);
    }
}
