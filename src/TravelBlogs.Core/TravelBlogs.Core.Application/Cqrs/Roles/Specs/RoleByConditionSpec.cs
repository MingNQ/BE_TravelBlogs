using TravelBlogs.Core.Application.Common.Specification;
using TravelBlogs.Core.Application.Cqrs.Roles.Params;
using TravelBlogs.Core.Application.Dto.Authorization.Role;
using TravelBlogs.Core.Domain.Entities.Identity;

namespace TravelBlogs.Core.Application.Cqrs.Roles.Specs;

public class RoleByConditionSpec(SearchRoleParam param) : BaseSpec<Role, RoleDto>(param);