using MediatR;
using TravelBlogs.Core.Application.Common.Models;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Common.Responses;
using TravelBlogs.Core.Application.Common.Services;
using TravelBlogs.Core.Application.Cqrs.Users.Params;
using TravelBlogs.Core.Application.Cqrs.Users.Specs;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.User;
using TravelBlogs.Core.Domain.Entities.Identity;

namespace TravelBlogs.Core.Application.Cqrs.Users.Queries;

public class GetUserByConditionQuery : SearchUserParam,
    IRequest<ResponseBase<PaginationResponse<UserDto>>>;

public class GetUserByConditionQueryHandler(
    IReadRepository<User> userRepository,
    IPaginationService paginationService)
    : IRequestHandler<GetUserByConditionQuery, ResponseBase<PaginationResponse<UserDto>>>
{
    public async Task<ResponseBase<PaginationResponse<UserDto>>> Handle(
        GetUserByConditionQuery request, CancellationToken cancellationToken)
    {
        var spec = new UserByConditionSpec(request);
        var users = await paginationService.PaginatedListAsync(
            userRepository,
            spec,
            request.PageNumber,
            request.PageSize,
            cancellationToken);

        // filePathService.BindFullPaths(users.Data);

        return new ResponseBase<PaginationResponse<UserDto>>(users);
    }
}