using MediatR;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Common.Responses;
using TravelBlogs.Core.Application.Cqrs.Users.Specs;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.User;
using TravelBlogs.Core.Domain.Entities.Identity;
using TravelBlogs.Core.Shared.Constants;

namespace Application.Cqrs.Users.Queries;

public class GetUserByIdQuery : IRequest<ResponseBase<UserDto>>
{
    public int Id { get; set; }
}

public class GetUserByIdQueryHandler(
    IReadRepository<User> userRepository)
    : IRequestHandler<GetUserByIdQuery, ResponseBase<UserDto>>
{
    public async Task<ResponseBase<UserDto>> Handle(
        GetUserByIdQuery request,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.FirstOrDefaultAsync(new UserByIdSpec(request.Id), cancellationToken)
                   ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(User), request.Id));

        // filePathService.BindFullPaths(user.Avatar);

        return new ResponseBase<UserDto>(user);
    }
}