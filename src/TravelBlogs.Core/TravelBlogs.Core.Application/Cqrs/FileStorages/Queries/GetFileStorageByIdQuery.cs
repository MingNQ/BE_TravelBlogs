using MediatR;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Cqrs.FileStorages.Specs;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.FileStorages;
using TravelBlogs.Core.Domain.Entities.Common;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.FileStorages.Queries;

public class GetFileStorageByIdQuery : IRequest<FileStorageDto>
{
    public long Id { get; set; }
}

public class GetFileStorageByIdQueryHandler(IReadRepository<FileStorage> fileStorageRepository)
    : IRequestHandler<GetFileStorageByIdQuery, FileStorageDto>
{
    public async Task<FileStorageDto> Handle(GetFileStorageByIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new FileStorageByIdSpec(request.Id);
        var fileStorage = await fileStorageRepository.FirstOrDefaultAsync(spec, cancellationToken)
            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(FileStorage), request.Id));

        return fileStorage;
    }
}