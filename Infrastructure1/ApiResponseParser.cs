using Newtonsoft.Json;
using System.Collections.Generic;

namespace Infrastructure.ExternalApis
{
    public class ApiResponseParser
    {
        public Dictionary<string, object>? ParseApiResponse(string apiResponse)
        {
            if (string.IsNullOrEmpty(apiResponse))
            {
                return null;
            }
            // Deserialize the JSON response into a dictionary
            var parsedResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(apiResponse);
            // Return the parsed response
            return parsedResponse;
        }
    }
}
