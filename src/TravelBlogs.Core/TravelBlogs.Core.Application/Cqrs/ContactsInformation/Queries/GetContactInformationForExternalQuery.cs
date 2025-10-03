using MediatR;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Cqrs.ContactsInformation.Specs;
using TravelBlogs.Core.Application.Dto.Integrates.Catalog;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.ContactsInformation.Queries;

public class GetContactInformationForExternalQuery : IRequest<List<ContactInformationExternalDto>>;

public class GetContactInformationForExternalQueryHandler(IReadRepository<ContactInformation> contactInformationRepository)
	: IRequestHandler<GetContactInformationForExternalQuery, List<ContactInformationExternalDto>>
{
	public async Task<List<ContactInformationExternalDto>> Handle(GetContactInformationForExternalQuery request, CancellationToken cancellationToken)
	{
		var spec = new ContactInformationForExternalSpec();
		var list = await contactInformationRepository.ListAsync(spec, cancellationToken);
		return list;
	}
}