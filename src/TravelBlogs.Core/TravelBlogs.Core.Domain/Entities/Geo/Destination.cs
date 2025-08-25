using TravelBlogs.Core.Domain.Common.Contracts;

namespace TravelBlogs.Core.Domain.Entities.Geo;

public class Destination : AuditableEntity<long>
{
    public string Name { get; private set; } = string.Empty;

    public long CountryId { get; private set; }
    public virtual Country? Country { get; set; }

    public static Destination Create(string name, long countryId)
    {
        return new Destination
        {
            Name = name,
            CountryId = countryId
        };
    }

    public void Update(string name)
    {
        Name = name;
    }
}