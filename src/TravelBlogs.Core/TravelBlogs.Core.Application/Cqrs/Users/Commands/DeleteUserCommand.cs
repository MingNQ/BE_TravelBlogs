using MediatR;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.Responses;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Domain.Entities.Identity;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Users.Commands;

public class DeleteUserCommand : IRequest<ResponseBase<long>>
{
    public long Id { get; set; }
}

public class DeleteUserCommandHandler(IUnitOfWork unitOfWork) 
    : IRequestHandler<DeleteUserCommand, ResponseBase<long>>
{
    private readonly IWriteRepository<User> _userRepository = unitOfWork.GetRepository<User>();

    public async Task<ResponseBase<long>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetFirstOrDefaultAsync(
                predicate: c => request.Id == c.Id, 
                disableTracking: false)
            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(User), request.Id));
        
        _userRepository.Delete(user);
        await unitOfWork.SaveChangesAsync();
        
        return new ResponseBase<long>(user.Id, MessageCommon.DeleteSuccess);
    }
}
