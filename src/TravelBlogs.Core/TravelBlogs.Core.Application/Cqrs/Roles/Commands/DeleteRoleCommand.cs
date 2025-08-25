using MediatR;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Domain.Entities.Identity;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Roles.Commands;

public class DeleteRoleCommand : IRequest<bool>
{
    public long Id { get; set; }
}

public class DeleteRoleCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteRoleCommand, bool>
{
    private readonly IWriteRepository<Role> _roleWriteRepository = unitOfWork.GetRepository<Role>();

    public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleWriteRepository.GetFirstOrDefaultAsync(
            predicate: r => r.Id == request.Id,
            disableTracking: false)
            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Role), request.Id));

        _roleWriteRepository.Delete(role);
        await unitOfWork.SaveChangesAsync();

        return true;
    }
}