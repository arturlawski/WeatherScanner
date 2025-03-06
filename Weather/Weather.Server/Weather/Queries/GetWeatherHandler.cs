using MediatR;
using WeatherSofomo.Domain;
using WeatherSofomo.Web.Weather.Model;

namespace WeatherSofomo.Web.Weather.Queries;

public record GetWeatherRequest : IRequest<WeatherDto>
{
    public Guid Id { get; set; }
}

public class GetWeatherHandler : IRequestHandler<GetWeatherRequest, WeatherDto>
{
    private readonly IWeatherRepository weatherRepository;
    public GetWeatherHandler(IWeatherRepository weatherRepository)
    {
        this.weatherRepository = weatherRepository;
    }
    
    public async Task<WeatherDto> Handle(GetWeatherRequest request, CancellationToken cancellationToken)
    {
        var weather = await weatherRepository.GetWeatherAsync(request.Id);
        return new WeatherDto(weather);
    }
}