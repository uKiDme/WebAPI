using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Infrastructure.Persistence;
using WebApi.Application;
using WebApi.Application.Services;
using Infrastructure.Repositories;
using Infrastructure.DependencyInjection;
using Infrastructure.ExternalApis;
using Application.MappingProfiles;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Check if the application is running in the development environment
            if (env.IsDevelopment())
            {
                // Enable developer exception page
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Use exception handler middleware and HSTS in production environment
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            // Map controllers and their actions as endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add MVC controllers as services to the application's service container
            services.AddControllers();

            // Add scoped services for dependency injection
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

            // Add infrastructure services and repositories
            services.AddInfrastructure(Configuration);

            // Add the OpenMeteoApiClient as a scoped service
            services.AddScoped<OpenMeteoApiClient>();

            // Add AutoMapper and specify the assembly containing the mapping profiles
            services.AddAutoMapper(typeof(Startup));
        }
    }
}