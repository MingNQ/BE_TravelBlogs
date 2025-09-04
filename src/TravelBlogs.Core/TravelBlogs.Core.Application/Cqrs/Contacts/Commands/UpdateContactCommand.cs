using Mapster;
using MediatR;
using System.Text.Json.Serialization;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.Responses;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Contact;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Contacts.Commands;

public class UpdateContactCommand : ContactBaseCommand, IRequest<ResponseBase<ContactDto>>
{
    [JsonIgnore]
    public long Id { get; private set; }

    public UpdateContactCommand SetID(long id) { Id = id; return this; }

}

public class UpdateContactCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateContactCommand, ResponseBase<ContactDto>>
{

    private readonly IWriteRepository<Contact> _contactRepository = unitOfWork.GetRepository<Contact>();
    public async Task<ResponseBase<ContactDto>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var entity = await _contactRepository.GetFirstOrDefaultAsync(
            predicate: x => x.Id == request.Id,
            disableTracking: false)
        ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Contact), request.Id));
        entity.Update(request.Subject, request.Content);
        _contactRepository.Update(entity);
        await unitOfWork.SaveChangesAsync();
        return new ResponseBase<ContactDto>(entity.Adapt<ContactDto>(), MessageCommon.UpdateSuccess);
    }
}