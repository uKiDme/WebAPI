
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Domain.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherForecastDto>> GetWeatherForecastsAsync();
        Task AddWeatherForecastsAsync(IEnumerable<WeatherForecastDto> forecasts);
    }
}
