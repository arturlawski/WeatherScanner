namespace WeatherSofomo.Domain;

public interface IWeatherRepository
{
    Task<IEnumerable<WeatherEntity>> GetWeathersAsync(int take, int skip);

    Task<WeatherEntity> GetWeatherAsync(Guid weatherId);

    Task AddWeatherAsync(WeatherEntity weather);

    Task UpdateWeatherAsync(WeatherEntity weather);

    Task DeleteWeatherAsync(Guid weatherId);

    int GetWeatherCount();
}