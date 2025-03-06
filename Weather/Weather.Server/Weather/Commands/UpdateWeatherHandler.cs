using MediatR;
using System.Threading.Tasks;
using WeatherSofomo.Domain;
using WeatherSofomo.Persistence;
using WeatherSofomo.Web.Weather.Commands;
using WeatherSofomo.Web.Weather.Model;
using BadHttpRequestException = Microsoft.AspNetCore.Http.BadHttpRequestException;

namespace WeatherSofomo.Web.Weather.Commands;

public record UpdateWeatherRequest : CreateWeatherRequest
{
    public Guid Id { get; init; }
}

public class UpdateWeatherHandler : IRequestHandler<UpdateWeatherRequest, WeatherDto>
{
    private readonly IWeatherRepository weatherRepository;
    private readonly IWeatherService weatherService;
    public UpdateWeatherHandler(IWeatherRepository weatherRepository, IWeatherService weatherService)
    {
        this.weatherRepository = weatherRepository;
        this.weatherService = weatherService;
    }

    public async Task<WeatherDto> Handle(UpdateWeatherRequest request, CancellationToken cancellationToken)
    {
        var toUpdate = await weatherRepository.GetWeatherAsync(request.Id);
        await UpdateModel(toUpdate, request);
        await weatherRepository.UpdateWeatherAsync(toUpdate);
        return new WeatherDto(toUpdate);
    }

    private async Task UpdateModel(WeatherEntity dbProduct, UpdateWeatherRequest requestWeather)
    {
        var weather = await weatherService.GetWeatherAsync(requestWeather.Latitude, requestWeather.Longitude);
        //dbProduct.WeatherJson = System.Text.Json.JsonSerializer.Serialize(weather?.Current);
        dbProduct.WeatherJson = weather;
    }
}