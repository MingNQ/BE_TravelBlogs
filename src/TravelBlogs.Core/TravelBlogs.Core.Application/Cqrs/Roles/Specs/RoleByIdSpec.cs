using Ardalis.Specification;
using TravelBlogs.Core.Application.Dto.Authorization.Role;
using TravelBlogs.Core.Domain.Entities.Identity;

namespace TravelBlogs.Core.Application.Cqrs.Roles.Specs;

public class RoleByIdSpec : Specification<Role, RoleDto>
{
    public RoleByIdSpec(long id)
    {
        Query.Where(r => r.Id == id);
    }
}