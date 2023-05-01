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
        private static readonly string[] Summaries = new[] {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"};
    
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
            return Enumerable.Range(1, 5).Select(index => new WeatherForecastDto
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
           .ToArray();
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
