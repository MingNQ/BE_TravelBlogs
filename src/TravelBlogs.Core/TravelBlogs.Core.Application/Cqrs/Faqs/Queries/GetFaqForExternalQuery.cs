using MediatR;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Cqrs.Faqs.Specs;
using TravelBlogs.Core.Application.Dto.Integrates.Catalog;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Faqs.Queries;

public class GetFaqForExternalQuery : IRequest<List<FaqExternalDto>>;

public class GetFaqForExternalQueryHandler(IReadRepository<Faq> faqRepository)
	: IRequestHandler<GetFaqForExternalQuery, List<FaqExternalDto>>
{
	public async Task<List<FaqExternalDto>> Handle(GetFaqForExternalQuery request, CancellationToken cancellationToken)
	{
		var spec = new FaqForExternalSpec();
		var list = await faqRepository.ListAsync(spec, cancellationToken);
		return list;
	}
}