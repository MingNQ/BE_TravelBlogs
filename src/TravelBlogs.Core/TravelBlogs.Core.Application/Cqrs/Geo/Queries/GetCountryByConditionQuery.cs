using MediatR;
using TravelBlogs.Core.Application.Common.Models;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Common.Services;
using TravelBlogs.Core.Application.Cqrs.Geo.Params;
using TravelBlogs.Core.Application.Cqrs.Geo.Specs;
using TravelBlogs.Core.Application.Dto.Integrates.Geo;
using TravelBlogs.Core.Domain.Entities.Geo;

namespace TravelBlogs.Core.Application.Cqrs.Geo.Queries;

public class GetCountryByConditionQuery : SearchCountryParam, IRequest<PaginationResponse<CountryInfo>>;

public class GetCountryByConditionQueryHandler(
    IReadRepository<Country> countryRepository,
    IPaginationService paginationService)
    : IRequestHandler<GetCountryByConditionQuery, PaginationResponse<CountryInfo>>
{
    public async Task<PaginationResponse<CountryInfo>> Handle(GetCountryByConditionQuery request, CancellationToken cancellationToken)
    {
        var spec = new CountryByConditionSpec(request);
        var result = await paginationService.PaginatedListAsync(
            countryRepository,
            spec,
            request.PageNumber,
            request.PageSize,
            cancellationToken
        );

        return result;
    }
}