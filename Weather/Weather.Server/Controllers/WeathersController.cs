using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherSofomo.Web.Weather.Commands;
using WeatherSofomo.Web.Weather.Queries;

namespace WeatherSofomo.Web.Controllers;

[ApiController]
[Route("api/weathers")]
public class WeathersController : ControllerBase
{
    private readonly IMediator mediator;
    public WeathersController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetWeathers([FromQuery] int skip, [FromQuery] int take)
    {
        var result = await mediator.Send(new GetWeathersRequest {Skip = skip, Take = take});
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetWeather(Guid id)
    {
        var result = await mediator.Send(new GetWeatherRequest {Id = id});
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteWeather(Guid id)
    {
        await mediator.Send(new DeleteWeatherRequest {Id = id});
        return Ok(NoContent());
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateWeather(Guid id, UpdateWeatherRequest request)
    {
        var result = await mediator.Send(request with {Id = id});
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateWeather(CreateWeatherRequest request)
    {
        var result = await mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("count")]
    public async Task<IActionResult> GetWeathersCount()
    {
        var result = await mediator.Send(new GetWeathersCountRequest());
        return Ok(result);
    }
    
}