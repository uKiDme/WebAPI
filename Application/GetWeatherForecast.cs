using Domain.Entities;
using Infrastructure.ExternalApis;

namespace Application.Services
{
    public class WeatherService
    {
        private readonly OpenMeteoApiClient openMeteoApiClient;

        public WeatherService(OpenMeteoApiClient openMeteoApiClient)
        {
            this.openMeteoApiClient = openMeteoApiClient;
        }

        public void GetWeatherForecast(double latitude, double longitude)
        {
            string? weatherForecast = openMeteoApiClient.GetWeatherForecast(latitude, longitude);
            if (weatherForecast != null)
            {
                // Process the weather forecast
                // ...

            }
            else
            {
                // Handle the case when the weather forecast is null
                // ...

            }
        }
    }
}
