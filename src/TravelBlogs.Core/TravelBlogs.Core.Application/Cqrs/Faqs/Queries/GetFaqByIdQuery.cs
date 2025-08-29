using MediatR;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Common.Responses;
using TravelBlogs.Core.Application.Cqrs.Faqs.Specs;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Faq;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Faqs.Queries;

public class GetFaqByIdQuery : IRequest<FaqDto>
{
    public long Id { get; set; }
}

public class GetFaqByIdQueryHandler(IReadRepository<Faq> repo)
    : IRequestHandler<GetFaqByIdQuery, FaqDto>
{
    public async Task<FaqDto> Handle(GetFaqByIdQuery request, CancellationToken ct)
    {
        var faq = await repo.FirstOrDefaultAsync(new FaqByIdSpec(request.Id), ct)
                  ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Faq), request.Id));

        return faq;
    }
}