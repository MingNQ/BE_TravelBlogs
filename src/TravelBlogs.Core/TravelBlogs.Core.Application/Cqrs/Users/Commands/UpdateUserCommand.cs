using System.Text.Json.Serialization;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.Responses;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.User;
using TravelBlogs.Core.Domain.Entities.Identity;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Users.Commands;

public class UpdateUserCommand : UserBaseCommand, IRequest<ResponseBase<UserDto>>
{
    [JsonIgnore]
    public long Id { get; private set; }

    public UpdateUserCommand SetId(long id)
    {
        Id = id;
        return this;
    }
}

public class UpdateUserCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateUserCommand, ResponseBase<UserDto>>
{
    private readonly IWriteRepository<User> _userRepository = unitOfWork.GetRepository<User>();

    public async Task<ResponseBase<UserDto>> Handle(
        UpdateUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetFirstOrDefaultAsync(
            predicate: c => c.Id == request.Id,
            include: x => x.Include(o => o.UserRoles),
                disableTracking: false)
            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(User), request.Id));

        user.SetEmail(request.Email);
        user.UpdateName(request.FirstName, request.LastName);

        if (!string.IsNullOrEmpty(request.PhoneNumber))
        {
            user.SetPhoneNumber(request.PhoneNumber);
        }

        if (request.AvatarId.HasValue)
        {
            user.SetAvatar(request.AvatarId.Value);
        }

        // Update roles using domain method
        user.UpdateRoles(request.RoleIds);

        _userRepository.Update(user);
        await unitOfWork.SaveChangesAsync();

        return new ResponseBase<UserDto>(user.Adapt<UserDto>(), MessageCommon.UpdateSuccess);
    }
}