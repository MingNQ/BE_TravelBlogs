using Ardalis.Specification;
using TravelBlogs.Core.Application.Dto.Integrates.Catalog;
using TravelBlogs.Core.Domain.Common.Enums;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Categories.Specs;

public sealed class CategoryHasBlogSpec : Specification<Category, CategoryExternalDto>
{
    public CategoryHasBlogSpec()
    {
        Query.Where(x => 
            x.Blogs.Count(b => b.Status == BlogStatusEnum.Approved) >= 2);
    }
}