using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.Responses;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Contact;
using TravelBlogs.Core.Domain.Entities.Identity;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Contacts.Commands
{
    public class DeleteContactCommand : IRequest<long>
    {
        public long id { get; set; }
    }
    public class DeleteContactCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteContactCommand, long>
    {
        private readonly IWriteRepository<Contact> _repository = unitOfWork.GetRepository<Contact>();
        public async Task<long> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetFirstOrDefaultAsync(
                predicate: x => x.Id == request.id,
                disableTracking: false)
                ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Contact),request.id));

            _repository.Delete(entity);
            unitOfWork.SaveChangesAsync();
            return entity.Id;
        }

    }
}
