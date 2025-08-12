using Ardalis.Specification;
using TravelBlogs.Core.Application.Common.Specification;
using TravelBlogs.Core.Application.Cqrs.Users.Params;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.User;
using TravelBlogs.Core.Domain.Entities.Identity;

namespace TravelBlogs.Core.Application.Cqrs.Users.Specs;

public sealed class UserByConditionSpec : BaseSpec<User, UserDto>
{
    public UserByConditionSpec(SearchUserParam param) : base(param)
    {
        Query.Include(x => x.UserRoles).ThenInclude(x => x.Role);
    }
}

public sealed class UserByIdSpec : Specification<User, UserDto>
{
    public UserByIdSpec(int id)
    {
        Query.Where(x => x.Id == id);

        Query.Include(x => x.UserRoles).ThenInclude(x => x.Role);
    }
}