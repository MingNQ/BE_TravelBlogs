using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using TravelBlogs.Core.Domain.Entities;
namespace TravelBlogs.Core.Application.Cqrs.Categories.Specs;
public class CategoryByIdSpec : Specification<Category>, ISingleResultSpecification
{
    public CategoryByIdSpec(long categoryId) => Query.Where(c => c.Id == categoryId);
}