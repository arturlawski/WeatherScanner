using FluentValidation;
using WeatherSofomo.Web.Weather.Commands;

namespace WeatherSofomo.Web.Weather.Validation;

public class UpdateWeatherRequestValidator : AbstractValidator<CreateWeatherRequest>
{
    public UpdateWeatherRequestValidator()
    {
        RuleFor(x => x.Latitude)
            .NotEmpty()
            .InclusiveBetween(-90, 90)
            .WithMessage("Latitude must be between -90 and 90");

        RuleFor(x => x.Longitude)
            .NotEmpty()
            .InclusiveBetween(-180, 180)
            .WithMessage("Longitude must be between -180 and 180");
    }
}