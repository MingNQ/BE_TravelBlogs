using TravelBlogs.Core.Domain.Common.Contracts;

namespace TravelBlogs.Core.Domain.Entities.Geo;

public class Country : AuditableEntity<long>
{
    public string Name { get; private set; } = string.Empty;
    public string Iso2 { get; private set; } = string.Empty;
    public string Iso3 { get; private set; } = string.Empty;
    private readonly List<Destination> _cities = [];
    public IReadOnlyCollection<Destination> Cities => _cities.AsReadOnly();

    public static Country Create(string name, string iso2, string iso3)
    {
        return new Country
        {
            Name = name,
            Iso2 = iso2,
            Iso3 = iso3
        };
    }

    public void Update(string name, string iso2, string iso3)
    {
        Name = name;
        Iso2 = iso2;
        Iso3 = iso3;
    }

    public void AddDestination(Destination destination)
    {
        _cities.Add(destination);
    }

    public void RemoveDestination(Destination destination)
    {
        _cities.Remove(destination);
    }

    public void ClearDestinations()
    {
        _cities.Clear();
    }

    public void AddDestinations(IEnumerable<string> destinations)
    {
        _cities.AddRange(destinations.Select(x => Destination.Create(x, Id)));
    }

    public void UpdateDestinations(List<string> cities)
    {
        var toRemove = _cities.Where(c => !cities.Contains(c.Name)).ToList();
        foreach (var city in toRemove)
        {
            _cities.Remove(city);
        }

        var existingCityNames = _cities.Select(c => c.Name).ToHashSet();
        var toAdd = cities.Where(c => !existingCityNames.Contains(c)).ToList();
        foreach (var city in toAdd)
        {
            _cities.Add(Destination.Create(city, Id));
        }
        
    }
}