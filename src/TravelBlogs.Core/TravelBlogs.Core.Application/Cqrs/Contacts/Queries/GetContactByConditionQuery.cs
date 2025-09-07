using MediatR;
using TravelBlogs.Core.Application.Common.Models;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Common.Services;
using TravelBlogs.Core.Application.Cqrs.Contacts.Specs;
using TravelBlogs.Core.Application.Cqrs.Faqs.Params;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Contact;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Contacts.Queries;

public class GetContactByConditionQuery : SearchFaqParam, IRequest<PaginationResponse<ContactDto>>;
public class GetContactByConditionQueryHandler(
    IReadRepository<Contact> repo,
    IPaginationService paginationService)
    : IRequestHandler<GetContactByConditionQuery, PaginationResponse<ContactDto>>
{
    public async Task<PaginationResponse<ContactDto>> Handle(GetContactByConditionQuery request, CancellationToken cancellationToken)
    {
        var spec = new ContactByConditionSpec(request);
        var result = await paginationService.PaginatedListAsync(
            repo, spec, request.PageNumber, request.PageSize, cancellationToken);
        return result;
    }
}