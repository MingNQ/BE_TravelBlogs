using MediatR;
using TravelBlogs.Core.Application.Common.Models;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Common.Services;
using TravelBlogs.Core.Application.Cqrs.ContactsInformation.Params;
using TravelBlogs.Core.Application.Cqrs.ContactsInformation.Specs;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.ContactInformation;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.ContactsInformation.Queries;

public class GetContactInformationByConditionQuery : SearchContactInformationParam, IRequest<PaginationResponse<ContactInformationDto>>;

public class GetContactInformationByConditionQueryHandler(
    IReadRepository<ContactInformation> contactInformationRepository,
    IPaginationService paginationService)
    : IRequestHandler<GetContactInformationByConditionQuery, PaginationResponse<ContactInformationDto>>
{
    public async Task<PaginationResponse<ContactInformationDto>> Handle(GetContactInformationByConditionQuery request, CancellationToken cancellationToken)
    {
        var spec = new ContactInformationByConditionSpec(request);
        var result = await paginationService.PaginatedListAsync(
            contactInformationRepository,
            spec,
            request.PageNumber,
            request.PageSize,
            cancellationToken);

        return result;
    }
}