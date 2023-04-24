using Infrastructure.Persistence;

namespace Infrastructure.DependencyInjection
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("MyDatabaseConnectionString")
                )
            );

            services.AddScoped<IMyDbContext>(provider => provider.GetService<MyDbContext>());

            return services;
        }
    }
}
