using MediatR;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Cqrs.Roles.Specs;
using TravelBlogs.Core.Application.Dto.Authorization.Role;
using TravelBlogs.Core.Domain.Entities.Identity;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Roles.Queries;

public class GetRoleByIdQuery : IRequest<RoleDto>
{
    public long Id { get; set; }
}

public class GetRoleByIdQueryHandler(IReadRepository<Role> roleRepository) : IRequestHandler<GetRoleByIdQuery, RoleDto>
{
    public async Task<RoleDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new RoleByIdSpec(request.Id);
        var role = await roleRepository.FirstOrDefaultAsync(spec, cancellationToken)
            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Role), request.Id));

        return role;
    }
}