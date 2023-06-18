using RestSharp;
using System.Threading.Tasks;

namespace Infrastructure.ExternalApis
{
    public class OpenMeteoApiClient
    {
        private readonly string apiUrl = "https://api.open-meteo.com/v1/forecast";
        private readonly ApiResponseParser apiResponseParser;
        public OpenMeteoApiClient(ApiResponseParser apiResponseParser)
        {
            this.apiResponseParser = apiResponseParser;
        }
        public async Task<string?> GetWeatherForecast(double latitude, double longitude)
        {
            var client = new RestClient(apiUrl);
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddParameter("latitude", latitude);
            request.AddParameter("longitude", longitude);
            request.AddParameter("current_weather", true);

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                string? apiResponse = response.Content;
                if (string.IsNullOrEmpty(apiResponse))
                {
                    return null;
                }
                var parsedResponse = apiResponseParser.ParseApiResponse(apiResponse);
                return parsedResponse;
            }
            else
            {
                throw new Exception("Failed to retrieve weather forecast from the Open-Meteo API.");
            }
        }
    }
}
