using MediatR;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Common.Responses;
using TravelBlogs.Core.Application.Cqrs.Contacts.Specs;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Contact;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Contacts.Queries;

public class GetContactByIdQuery:IRequest<ResponseBase<ContactDto>>
{
    public long ID { get; set; }
}

public class GetFaqByIdQueryHandler(IReadRepository<Contact> repo)
    : IRequestHandler<GetContactByIdQuery, ResponseBase<ContactDto>>
{
    public async Task<ResponseBase<ContactDto>> Handle(GetContactByIdQuery request,CancellationToken cancellationToken)
    {
        var contact =  await repo.FirstOrDefaultAsync(new ContactByIdSpec(request.ID),cancellationToken)
                            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Contact),request.ID)); 
        return new ResponseBase<ContactDto>(contact);
    }
}