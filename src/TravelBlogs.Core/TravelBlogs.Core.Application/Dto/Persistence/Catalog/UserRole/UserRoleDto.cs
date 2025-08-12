
using TravelBlogs.Core.Application.Dto.Authorization.Role;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.User;

namespace TravelBlogs.Core.Application.Dto.Persistence.Catalog.UserRole;

public class UserRoleDto
{
    public long UserId { get; set; }

    public long RoleId { get; set; }

    public UserDto User { get; set; } = new();

    public RoleDto Role { get; set; } = new();
}