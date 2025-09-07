using TravelBlogs.Core.Application.Common.Specification;
using TravelBlogs.Core.Application.Cqrs.Categories.Params;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Categories;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Categories.Specs;

public class CategoryByConditionSpec(SearchCategoryParam param) : BaseSpec<Category, CategoryDto>(param);