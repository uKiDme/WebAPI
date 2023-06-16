using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Application;
using WebApi.Application.DTOs;

namespace WebApi.Controllers
{
    [ApiController] // Specifies that the controller should be treated as an API controller
    [Route("[controller]")] // Specifies the route template for the controller (here, it uses the controller name itself)
    public class WeatherForecastController : ControllerBase // Inherits from the ControllerBase class
    {
        private static readonly string[] Summaries = new[] {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"};

        private readonly IWeatherForecastService _weatherForecastService; // Stores an instance of the WeatherForecastService

        public WeatherForecastController(IWeatherForecastService weatherForecastService) // Constructor injection of IWeatherForecastService
        {
            _weatherForecastService = weatherForecastService; // Assigns the injected service to the private field
        }

        [HttpGet(Name = "GetWeatherForecast")] // Specifies a HTTP GET route for the action method
        public IEnumerable<WeatherForecastDto> Get() // Action method to retrieve weather forecasts
        {
            if (_weatherForecastService == null) 
            {
                throw new ArgumentNullException(nameof(_weatherForecastService)); 
            }
            return Enumerable.Range(1, 5).Select(index => new WeatherForecastDto // Generates a list of weather forecasts
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray(); // Converts the list to an array and returns it
        }

        [HttpPost] // Specifies a HTTP POST route for the action method
        public async Task<IActionResult> PostWeatherForecasts(IEnumerable<WeatherForecastDto> forecasts) // Action method to add weather forecasts
        {
            if (_weatherForecastService == null) 
            {
                throw new ArgumentNullException(nameof(_weatherForecastService));
            }
            await _weatherForecastService.AddWeatherForecasts(forecasts); // Calls the service method to add weather forecasts
            return Ok(); // Returns an HTTP 200 OK response
        }

        [HttpGet("external")] // Specifies a HTTP GET route for the action method with the "external" segment
        public async Task<IActionResult> GetExternalWeatherForecast(double latitude, double longitude) // Action method to retrieve external weather forecast
        {
            var forecast = await _weatherForecastService.GetExternalWeatherForecast(latitude, longitude); // Calls the service method to get external weather forecast
            return Ok(forecast); // Returns the forecast as an HTTP 200 OK response
        }
    }
}