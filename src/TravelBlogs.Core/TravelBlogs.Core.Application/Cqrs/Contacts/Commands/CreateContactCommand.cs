using Mapster;
using MediatR;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.Responses;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Contact;
using TravelBlogs.Core.Domain.Entities.Identity;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Contacts.Commands
{
    public class CreateContactCommand : ContactBaseCommand,IRequest<ResponseBase<ContactDto>>;
    public class CreateContactCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateContactCommand, ResponseBase<ContactDto>>
    {
        public readonly IWriteRepository<Contact> _contactRepository = unitOfWork.GetRepository<Contact>();
        public readonly IWriteRepository<User> _userRepository = unitOfWork.GetRepository<User>();
        public async Task<ResponseBase<ContactDto>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            bool exists = await _userRepository.ExistsAsync(x => x.Id == request.UserId);
            if(!exists){
                throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(User),request.UserId));
            }
            var entity = Contact.Create(request.Subject, request.Content, request.UserId);
            var result = await _contactRepository.InsertAsync(entity, cancellationToken);
            await unitOfWork.SaveChangesAsync();
            return new ResponseBase<ContactDto>(result.Entity.Adapt<ContactDto>(),MessageCommon.CreateSuccess);
        }
    }
}
