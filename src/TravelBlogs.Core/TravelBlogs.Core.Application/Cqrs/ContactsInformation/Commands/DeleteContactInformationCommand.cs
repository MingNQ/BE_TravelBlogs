using System.Text.Json.Serialization;
using MediatR;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.ContactsInformation.Commands;

public class DeleteContactInformationCommand : IRequest<long>
{
    public long Id { get; set; }
}

public class DeleteContactInformationCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteContactInformationCommand, long>
{
    private readonly IWriteRepository<ContactInformation> _contactInformationRepository = unitOfWork.GetRepository<ContactInformation>();

    public async Task<long> Handle(DeleteContactInformationCommand request, CancellationToken cancellationToken)
    {
        var contactInformation = await _contactInformationRepository.GetFirstOrDefaultAsync(
            predicate: x => x.Id == request.Id,
            disableTracking: false)
            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(ContactInformation), request.Id));

        _contactInformationRepository.Delete(contactInformation);
        await unitOfWork.SaveChangesAsync();

        return contactInformation.Id;
    }
}