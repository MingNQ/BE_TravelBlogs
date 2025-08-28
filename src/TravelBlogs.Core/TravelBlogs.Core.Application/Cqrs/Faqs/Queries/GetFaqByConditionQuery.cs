using MediatR;
using TravelBlogs.Core.Application.Common.Models;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Common.Responses;
using TravelBlogs.Core.Application.Common.Services;
using TravelBlogs.Core.Application.Cqrs.Faqs.Params;
using TravelBlogs.Core.Application.Cqrs.Faqs.Specs;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Faq;
using TravelBlogs.Core.Domain.Entities.Identity;

namespace TravelBlogs.Core.Application.Cqrs.Faqs.Queries;

public class GetFaqByConditionQuery : SearchFaqParam, IRequest<ResponseBase<PaginationResponse<FaqDto>>>;

public class GetFaqByConditionQueryHandler(
    IReadRepository<Faq> repo,
    IPaginationService paginationService)
    : IRequestHandler<GetFaqByConditionQuery, ResponseBase<PaginationResponse<FaqDto>>>
{
    public async Task<ResponseBase<PaginationResponse<FaqDto>>> Handle(GetFaqByConditionQuery request, CancellationToken ct)
    {
        var spec = new FaqByConditionSpec(request);
        var result = await paginationService.PaginatedListAsync(
            repo,
            spec,
            request.PageNumber,
            request.PageSize,
            ct);

        return new ResponseBase<PaginationResponse<FaqDto>>(result);
    }
}
