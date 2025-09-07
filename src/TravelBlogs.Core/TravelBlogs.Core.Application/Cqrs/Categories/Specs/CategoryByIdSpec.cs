using Ardalis.Specification;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Categories.Specs;

public class CategoryByIdSpec : Specification<Category>
{
    public CategoryByIdSpec(long categoryId) => Query.Where(c => c.Id == categoryId);
}