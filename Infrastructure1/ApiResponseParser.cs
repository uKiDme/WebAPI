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

            var parsedResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(apiResponse);
            //change to returned type data.
            return parsedResponse;
        }
    }
}
