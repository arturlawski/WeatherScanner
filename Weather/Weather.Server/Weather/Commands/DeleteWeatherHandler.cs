using MediatR;
using WeatherSofomo.Domain;
using WeatherSofomo.Persistence;

namespace WeatherSofomo.Web.Weather.Commands;
    
public record DeleteWeatherRequest : IRequest<Unit>
{
    public Guid Id { get; init; }
}

public class DeleteWeatherHandler : IRequestHandler<DeleteWeatherRequest, Unit>
{
    private readonly IWeatherRepository weatherRepository;

    public DeleteWeatherHandler(IWeatherRepository weatherRepository)
    {
        this.weatherRepository = weatherRepository;
    }
    
    public async Task<Unit> Handle(DeleteWeatherRequest request, CancellationToken cancellationToken)
    {
        await weatherRepository.DeleteWeatherAsync(request.Id);
        return Unit.Value;
    }
}