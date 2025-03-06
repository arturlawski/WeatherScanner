using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Weather.Persistance.WeatherSofomo.Persistence;
using WeatherSofomo.Domain;

namespace WeatherSofomo.Persistence;

public static class PersistenceServicesInstaller
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<WeatherDbContext>(options =>
                options.UseInMemoryDatabase("WeatherDatabase"));
        services.AddTransient<IWeatherService, WeatherService>();
        services.AddTransient<IWeatherRepository, WeatherRepository>();
        return services;
    }
}
