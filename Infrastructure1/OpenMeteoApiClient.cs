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

        public async Task<Dictionary<string, object>?> GetWeatherForecast(double latitude, double longitude)
        {
            // Create a new RestClient instance with the API URL
            var client = new RestClient(apiUrl);

            // Create a new RestRequest instance
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddParameter("latitude", latitude);
            request.AddParameter("longitude", longitude);
            request.AddParameter("current_weather", true);

            // Execute the request asynchronously and get the response
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                // Extract the API response content
                string? apiResponse = response.Content;

                // Check if the API response is null or empty
                if (string.IsNullOrEmpty(apiResponse))
                {
                    return null;
                }

                // Parse the API response using the ApiResponseParser
                var parsedResponse = apiResponseParser.ParseApiResponse(apiResponse);
                return parsedResponse;
            }
            else
            {
                // Throw an exception if the API request was unsuccessful
                throw new Exception("Failed to retrieve weather forecast from the Open-Meteo API.");
            }
        }
    }
}