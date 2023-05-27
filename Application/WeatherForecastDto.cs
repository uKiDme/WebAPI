namespace WebApi.Application.DTOs
{
    public class WeatherForecastDto
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF { get; set; }
        public string? Summary { get; set; }
    }
    public class MeteoApiForecastDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double GenerationTime { get; set; }
        public int UtcOffsetSeconds { get; set; }
        public string? Timezone { get; set; }
        public string? TimezoneAbbreviation { get; set; }
        public double Elevation { get; set; }
        public MeteoApiCurrentWeatherDto? CurrentWeather { get; set; }
    }

    public class MeteoApiCurrentWeatherDto
    {
        public double Temperature { get; set; }
        public double Windspeed { get; set; }
        public double WindDirection { get; set; }
        public int WeatherCode { get; set; }
        public int IsDay { get; set; }
        public DateTime Time { get; set; }
    }
}