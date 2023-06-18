using Newtonsoft.Json;
using System.Collections.Generic;

namespace Infrastructure.ExternalApis
{
    public class ApiResponseParser
    {
        public string? ParseApiResponse(string apiResponse)
        {
            if (string.IsNullOrEmpty(apiResponse))
            {
                return null;
            }
            return apiResponse;
        }
    }
}
