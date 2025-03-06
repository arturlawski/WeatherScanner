using MediatR;
using WeatherSofomo.Domain;

namespace WeatherSofomo.Web.Weather.Queries;

public record GetWeathersCountRequest : IRequest<int>
{
}

public class GetWeathersCountHandler : IRequestHandler<GetWeathersCountRequest, int>
{
    private readonly IWeatherRepository weatherRepository;
    public GetWeathersCountHandler(IWeatherRepository weatherRepository)
    {
        this.weatherRepository = weatherRepository;
    }
    public Task<int> Handle(GetWeathersCountRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(weatherRepository.GetWeatherCount());
    }
}