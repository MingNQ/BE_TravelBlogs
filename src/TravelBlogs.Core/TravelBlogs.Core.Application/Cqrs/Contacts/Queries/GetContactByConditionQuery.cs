using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.Core.Application.Common.Models;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Common.Responses;
using TravelBlogs.Core.Application.Common.Services;
using TravelBlogs.Core.Application.Cqrs.Faqs.Params;
using TravelBlogs.Core.Application.Cqrs.Faqs.Queries;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Contact;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Faq;
using TravelBlogs.Core.Domain.Entities.Identity;
using TravelBlogs.Core.Application.Cqrs.Contacts.Specs;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Contacts.Queries
{
    public class GetContactByConditionQuery : SearchFaqParam, IRequest<ResponseBase<PaginationResponse<ContactDto>>>;
    public class GetContactByConditionQueryHandler(
    IReadRepository<Contact> repo,
    IPaginationService paginationService)
    : IRequestHandler<GetContactByConditionQuery, ResponseBase<PaginationResponse<ContactDto>>>
    {
        public async Task<ResponseBase<PaginationResponse<ContactDto>>> Handle(GetContactByConditionQuery request,CancellationToken cancellationToken)
        {
            var spec = new ContactByConditionSpec(request);
            var result = await paginationService.PaginatedListAsync(
                repo, spec, request.PageNumber,request.PageSize,cancellationToken);
            return new ResponseBase<PaginationResponse<ContactDto>>(result);
        }
    }
}
