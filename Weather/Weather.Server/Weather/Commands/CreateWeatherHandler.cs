using System.Text.Json;
using MediatR;
using WeatherSofomo.Domain;
using WeatherSofomo.Web.Weather.Model;
using WeatherSofomo.Persistence;

namespace WeatherSofomo.Web.Weather.Commands;
public record CreateWeatherRequest : IRequest<WeatherDto>
{
    public float Latitude { get; init; }
    public float Longitude { get; init; }
}

public class CreateWeatherHandler : IRequestHandler<CreateWeatherRequest, WeatherDto>
{
    private readonly IWeatherRepository weatherRepository;
    private readonly IWeatherService weatherService;

    public CreateWeatherHandler(IWeatherRepository weatherRepository, IWeatherService weatherService)
    {
        this.weatherRepository = weatherRepository;
        this.weatherService = weatherService;
    }

    public async Task<WeatherDto> Handle(CreateWeatherRequest request, CancellationToken cancellationToken)
    {
        var weatherJson = await weatherService.GetWeatherAsync(request.Latitude, request.Longitude);
        var newWeather = new WeatherEntity()
        {
            WeatherJson = weatherJson,
            Longitude = request.Longitude,
            Latitude = request.Latitude
        };

        await weatherRepository.AddWeatherAsync(newWeather);
        return new WeatherDto(newWeather);
    }
}
