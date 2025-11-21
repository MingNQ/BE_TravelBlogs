using Ardalis.Specification;
using TravelBlogs.Core.Application.Common.Specification;
using TravelBlogs.Core.Application.Cqrs.Categories.Params;
using TravelBlogs.Core.Application.Dto.Integrates.Catalog;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Categories.Specs;

public sealed class CategoryByConditionSpec : BaseSpec<Category>
{
    public CategoryByConditionSpec(SearchCategoryParam param)
    {
        Query.Include(x => x.Blogs);
    }
}

public sealed class CategoryForExternalSpec : Specification<Category, CategoryExternalDto>
{
    public CategoryForExternalSpec()
    {
        Query.Select(x => new CategoryExternalDto
        {
            Id = x.Id,
            Name = x.Name
        });
    }
}