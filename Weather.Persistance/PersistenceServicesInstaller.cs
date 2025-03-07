using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Weather.Persistance.WeatherSofomo.Persistence;
using WeatherSofomo.Domain;

namespace WeatherSofomo.Persistence;

public static class PersistenceServicesInstaller
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        var inMemoryDatabaseRoot = new InMemoryDatabaseRoot();
        services.AddDbContext<WeatherDbContext>(options =>
            options.UseInMemoryDatabase("WeatherDatabase", inMemoryDatabaseRoot));
        services.AddScoped<IWeatherService, WeatherService>();
        services.AddScoped<IWeatherRepository, WeatherRepository>();
        return services;
    }
}
