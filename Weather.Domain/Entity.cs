namespace WeatherSofomo.Domain;

public abstract class Entity
{
    public Guid Id { get; private init; }
    public DateTime DateCreated { get; private init; }

    public Entity()
    {
        Id = Guid.NewGuid();
        DateCreated = DateTime.UtcNow;
    }
}