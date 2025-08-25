using Mapster;
using MediatR;
using TravelBlogs.Core.Application.Common.Models;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.Services;
using TravelBlogs.Core.Application.Cqrs.Roles.Params;
using TravelBlogs.Core.Application.Cqrs.Roles.Specs;
using TravelBlogs.Core.Application.Dto.Authorization.Role;
using TravelBlogs.Core.Domain.Entities.Identity;

namespace TravelBlogs.Core.Application.Cqrs.Roles.Queries;

public class GetRoleByConditionQuery : SearchRoleParam, IRequest<PaginationResponse<RoleDto>>;

public class GetRoleByConditionQueryHandler(
    IReadRepository<Role> roleRepository,
    IPaginationService paginationService)
    : IRequestHandler<GetRoleByConditionQuery, PaginationResponse<RoleDto>>
{
    public async Task<PaginationResponse<RoleDto>> Handle(GetRoleByConditionQuery request, CancellationToken cancellationToken)
    {
        var spec = new RoleByConditionSpec(request);
        var roles = await paginationService.PaginatedListAsync(
            roleRepository,
            spec,
            request.PageNumber,
            request.PageSize,
            cancellationToken);

        return roles;
    }
}