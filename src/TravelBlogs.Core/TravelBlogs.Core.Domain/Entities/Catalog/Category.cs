using TravelBlogs.Core.Domain.Common.Contracts;

namespace TravelBlogs.Core.Domain.Entities.Catalog;

public class Category : AuditableEntity<long>
{
    public string Name { get; private set; } = string.Empty;

    public static Category Create(string name)
    {
        return new Category
        {
            Name = name
        };
    }

    public void Update(string name)
    {
        Name = name;
    }
}