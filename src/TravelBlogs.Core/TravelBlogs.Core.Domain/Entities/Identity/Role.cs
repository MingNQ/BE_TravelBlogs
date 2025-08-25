using TravelBlogs.Core.Domain.Common.Contracts;

namespace TravelBlogs.Core.Domain.Entities.Identity;

public class Role : AuditableEntity<long>
{
    public string Name { get; private set; } = string.Empty;
    public string NormalizedName { get; private set; } = string.Empty;

    public static Role Create(string name)
    {
        return new Role
        {
            Name = name,
            NormalizedName = name.ToUpperInvariant()
        };
    }

    public void Update(string name)
    {
        Name = name;
        NormalizedName = name.ToUpperInvariant();
    }
}