using WeatherSofomo.Domain;

namespace WeatherSofomo.Web.Weather.Model;

public record WeatherDto
{
    public Guid Id { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public string WeatherJson { get; set; }
    public DateTime DateCreated { get; set; }
    
    public WeatherDto(WeatherEntity model)
    {
        Id = model.Id;
        Latitude = model.Latitude;
        Longitude = model.Longitude;
        WeatherJson = model.WeatherJson;
        DateCreated = model.DateCreated;
    }
}