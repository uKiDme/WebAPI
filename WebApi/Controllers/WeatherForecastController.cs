using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Application;
using WebApi.Application.DTOs;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecastDto> Get()
        {
            if (_weatherForecastService == null)
            {
                throw new ArgumentNullException(nameof(_weatherForecastService));
            }
            return _weatherForecastService.GetWeatherForecasts();
        }

        [HttpPost]
        public async Task<IActionResult> PostWeatherForecasts(IEnumerable<WeatherForecastDto> forecasts)
        {
            if (_weatherForecastService == null)
            {
                throw new ArgumentNullException(nameof(_weatherForecastService));
            }
            await _weatherForecastService.AddWeatherForecasts(forecasts);
            return Ok();
        }
    }
}
