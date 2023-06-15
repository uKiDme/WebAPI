using AutoMapper;
using Infrastructure.ExternalApis;
using WebApi.Application.DTOs;

namespace Application.MappingProfiles
{
    public class WeatherMappingProfile : Profile
    {
        public WeatherMappingProfile()
        {
            CreateMap<Dictionary<string, object>, MeteoApiForecastDto>()
                //.ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src["latitude"]))
                //.ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src["longitude"]))
                //.ForMember(dest => dest.GenerationTime, opt => opt.MapFrom(src => src["GenerationTime"]))
                //.ForMember(dest => dest.UtcOffsetSeconds, opt => opt.MapFrom(src => src["UtcOffsetSeconds"]))
                //.ForMember(dest => dest.Timezone, opt => opt.MapFrom(src => src["Timezone"]))
                //.ForMember(dest => dest.Elevation, opt => opt.MapFrom(src => src["Elevation"]))
                .ReverseMap();
            CreateMap<Dictionary<string, object>, MeteoApiCurrentWeatherDto>()
                //.ForMember(dest => dest.Temperature, opt => opt.MapFrom(src => src["temperature"]))
                //.ForMember(dest => dest.Windspeed, opt => opt.MapFrom(src => src["windspeed"]))
                //.ForMember(dest => dest.WindDirection, opt => opt.MapFrom(src => src["WindDirection"]))
                //.ForMember(dest => dest.WeatherCode, opt => opt.MapFrom(src => src["WeatherCode"]))
                //.ForMember(dest => dest.IsDay, opt => opt.MapFrom(src => src["IsDay"]))
                //.ForMember(dest => dest.Time, opt => opt.MapFrom(src => src["Time"]))
                .ReverseMap();
        }
    }
}
