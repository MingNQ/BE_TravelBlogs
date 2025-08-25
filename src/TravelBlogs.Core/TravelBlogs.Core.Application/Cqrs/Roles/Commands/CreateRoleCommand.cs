using Mapster;
using MediatR;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Authorization.Role;
using TravelBlogs.Core.Domain.Entities.Identity;

namespace TravelBlogs.Core.Application.Cqrs.Roles.Commands;

public class CreateRoleCommand : RoleBaseCommand, IRequest<RoleDto>;

public class CreateRoleCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateRoleCommand, RoleDto>
{
    private readonly IWriteRepository<Role> _roleWriteRepository = unitOfWork.GetRepository<Role>();

    public async Task<RoleDto> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = Role.Create(request.Name);

        var newRole = await _roleWriteRepository.InsertAsync(role, cancellationToken);
        await unitOfWork.SaveChangesAsync();

        return newRole.Entity.Adapt<RoleDto>();
    }
}