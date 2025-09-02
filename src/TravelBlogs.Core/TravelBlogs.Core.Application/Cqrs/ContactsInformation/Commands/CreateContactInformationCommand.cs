using Mapster;
using MediatR;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.ContactInformation;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.ContactsInformation.Commands;

public class CreateContactInformationCommand : ContactInformationBaseCommand, IRequest<ContactInformationDto>;

public class CreateContactInformationCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateContactInformationCommand, ContactInformationDto>
{
    private readonly IWriteRepository<ContactInformation> _contactInformationRepository = unitOfWork.GetRepository<ContactInformation>();

    public async Task<ContactInformationDto> Handle(CreateContactInformationCommand request, CancellationToken cancellationToken)
    {
        var contactInformation = ContactInformation.Create(
            request.Email,
            request.PhoneNumber,
            request.IsDefault
        );

        var newEntity = await _contactInformationRepository.InsertAsync(contactInformation, cancellationToken);
        await unitOfWork.SaveChangesAsync();

        return newEntity.Adapt<ContactInformationDto>();
    }
}