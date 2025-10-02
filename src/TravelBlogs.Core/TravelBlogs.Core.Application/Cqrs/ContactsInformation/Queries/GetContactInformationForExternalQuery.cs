using MediatR;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Cqrs.ContactsInformation.Specs;
using TravelBlogs.Core.Application.Dto.Integrates.Catalog;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.ContactsInformation.Queries;

public class GetContactInformationForExternalQuery : IRequest<List<ContactInformationExternalDto>>;

public class GetContactInformationForExternalQueryHandler(IReadRepository<ContactInformation> repo)
	: IRequestHandler<GetContactInformationForExternalQuery, List<ContactInformationExternalDto>>
{
	public async Task<List<ContactInformationExternalDto>> Handle(GetContactInformationForExternalQuery request, CancellationToken ct)
	{
		var spec = new ContactInformationForExternalSpec();
		var list = await repo.ListAsync(spec, ct);
		return list;
	}
}