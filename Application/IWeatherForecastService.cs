using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Application
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecastDto> GetWeatherForecasts();

        Task AddWeatherForecasts(IEnumerable<WeatherForecastDto> forecasts);
    }
}
