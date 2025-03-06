namespace WeatherSofomo.Domain;

public class WeatherEntity : Entity
{
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public string WeatherJson { get; set; }
}