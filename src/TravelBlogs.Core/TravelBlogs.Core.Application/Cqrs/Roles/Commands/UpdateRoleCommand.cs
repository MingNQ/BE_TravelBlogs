using System.Text.Json.Serialization;
using Mapster;
using MediatR;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Authorization.Role;
using TravelBlogs.Core.Domain.Entities.Identity;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Roles.Commands;

public class UpdateRoleCommand : RoleBaseCommand, IRequest<RoleDto>
{
    [JsonIgnore]
    public long Id { get; private set; }

    public void SetId(long id) => Id = id;
}

public class UpdateRoleCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateRoleCommand, RoleDto>
{
    private readonly IWriteRepository<Role> _roleRepository = unitOfWork.GetRepository<Role>();

    public async Task<RoleDto> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetFirstOrDefaultAsync(
            predicate: r => r.Id == request.Id,
            disableTracking: false)
            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Role), request.Id));

        role.Update(request.Name);

        _roleRepository.Update(role);
        await unitOfWork.SaveChangesAsync();

        return role.Adapt<RoleDto>();
    }
}