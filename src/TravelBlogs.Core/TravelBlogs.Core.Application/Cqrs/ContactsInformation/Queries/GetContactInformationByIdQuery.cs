using MediatR;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Cqrs.ContactsInformation.Specs;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.ContactInformation;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.ContactsInformation.Queries;

public class GetContactInformationByIdQuery : IRequest<ContactInformationDto>
{
    public long Id { get; set; }
}

public class GetContactInformationByIdQueryHandler(IReadRepository<ContactInformation> contactInformationRepository)
    : IRequestHandler<GetContactInformationByIdQuery, ContactInformationDto>
{
    public async Task<ContactInformationDto> Handle(GetContactInformationByIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new ContactInformationByIdSpec(request.Id);
        var contactInformation = await contactInformationRepository.FirstOrDefaultAsync(
            spec, cancellationToken)
            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(ContactInformation), request.Id));
        return contactInformation;
    }
}