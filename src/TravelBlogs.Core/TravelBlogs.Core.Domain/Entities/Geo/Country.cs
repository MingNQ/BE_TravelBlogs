using TravelBlogs.Core.Domain.Common.Contracts;

namespace TravelBlogs.Core.Domain.Entities.Geo;

public class Country : AuditableEntity<long>
{
    public string Name { get; set; } = string.Empty;
    private readonly List<Destination> _destinations = [];
    public IReadOnlyCollection<Destination> Destinations => _destinations.AsReadOnly();

    public static Country Create(string name)
    {
        return new Country
        {
            Name = name
        };
    }

    public void Update(string name)
    {
        Name = name;
    }

    public void AddDestination(Destination destination)
    {
        _destinations.Add(destination);
    }

    public void RemoveDestination(Destination destination)
    {
        _destinations.Remove(destination);
    }

    public void ClearDestinations()
    {
        _destinations.Clear();
    }

    public void AddDestinations(IEnumerable<Destination> destinations)
    {
        _destinations.AddRange(destinations);
    }
}