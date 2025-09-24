using Mapster;
using MediatR;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.FileStorages;
using TravelBlogs.Core.Domain.Entities.Common;

namespace TravelBlogs.Core.Application.Cqrs.FileStorages.Commands;

public class CreateFileStorageCommand : FileStorageBaseCommand, IRequest<FileStorageDto>;

public class CreateFileStorageCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateFileStorageCommand, FileStorageDto>
{
    private readonly IWriteRepository<FileStorage> _fileStorageRepository = unitOfWork.GetRepository<FileStorage>();

    public async Task<FileStorageDto> Handle(CreateFileStorageCommand request, CancellationToken cancellationToken)
    {
        var fileStorage = FileStorage.Create(
            request.FileName,
            request.FileUniqueName,
            request.Size,
            request.Type,
            request.Path,
            request.Extension);

        await _fileStorageRepository.InsertAsync(fileStorage, cancellationToken);
        await unitOfWork.SaveChangesAsync();

        return fileStorage.Adapt<FileStorageDto>();
    }
}