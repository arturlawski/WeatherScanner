using MediatR;
using System.Linq;
using WeatherSofomo.Domain;
using WeatherSofomo.Web.Weather.Model;
namespace WeatherSofomo.Web.Weather.Queries;

public record GetWeathersRequest : IRequest<IEnumerable<WeatherDto>>
{
    public int Skip { get; init; }
    public int Take { get; init; }
}

public class GetWeathersHandler : IRequestHandler<GetWeathersRequest, IEnumerable<WeatherDto>>
{
    private readonly IWeatherRepository weatherRepository;

    public GetWeathersHandler(IWeatherRepository weatherRepository)
    {
        this.weatherRepository = weatherRepository;
    }
    
    public async Task<IEnumerable<WeatherDto>> Handle(GetWeathersRequest request, CancellationToken cancellationToken)
    {
        var weathers = await weatherRepository.GetWeathersAsync(request.Take, request.Skip);
        return weathers.Select(x => new WeatherDto(x));
    }
}