using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.ContactInformation;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.ContactsInformation.Commands;

public class SetContactInformationDefaultCommand : IRequest<ContactInformationDto>
{
    [JsonIgnore]
    public long Id { get; private set; }
    public void SetId(long id)
    {
        Id = id;
    }
    public bool IsDefault { get; set; }
}

public class SetContactInformationDefaultCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<SetContactInformationDefaultCommand, ContactInformationDto>
{
    private readonly IWriteRepository<ContactInformation> _contactInformationRepository = unitOfWork.GetRepository<ContactInformation>();

    public async Task<ContactInformationDto> Handle(SetContactInformationDefaultCommand request, CancellationToken cancellationToken)
    {
        var contactInformation = await _contactInformationRepository.GetFirstOrDefaultAsync(
            predicate: x => x.Id == request.Id,
            disableTracking: false)
            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(ContactInformation), request.Id));

        await ValidateDefaultEntityHandler();

        contactInformation.SetDefault(request.IsDefault);

        _contactInformationRepository.Update(contactInformation);
        await unitOfWork.SaveChangesAsync();

        return contactInformation.Adapt<ContactInformationDto>();
    }

    private async Task ValidateDefaultEntityHandler()
    {
        var existingDefaultEntity = await _contactInformationRepository.GetFirstOrDefaultAsync(
            predicate: x => x.IsDefault,
            disableTracking: false
        );

        existingDefaultEntity?.SetDefault(false);
    }
}