using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Infrastructure.Persistence;
using WebApi.Application;
using WebApi.Application.Services;
using Infrastructure.Repositories;
using Domain.Interfaces;

namespace WebApi
{
    public class Startup
    {

        public IConfiguration? Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            //services.AddScoped<Domain.Interfaces.IWeatherForecastRepository, WeatherForecastRepository>();
            services.AddDbContext<MyDbContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });
        }
    }
}
