using RestSharp;

namespace Infrastructure.ExternalApis
{
    public class OpenMeteoApiClient
    {
        private readonly string apiUrl = "https://api.open-meteo.com/v1/forecast";

        public string? GetWeatherForecast(double latitude, double longitude)
        {
            var client = new RestClient(apiUrl);
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddParameter("latitude", latitude);
            request.AddParameter("longitude", longitude);
            request.AddParameter("current_weather", true);

            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                return response.Content;
            }
            else
            {
                throw new Exception("Failed to retrieve weather forecast from the Open-Meteo API.");
            }
        }
    }
}
