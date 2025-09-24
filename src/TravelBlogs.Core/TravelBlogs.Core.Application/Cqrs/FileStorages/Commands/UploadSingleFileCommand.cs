using MediatR;
using Microsoft.AspNetCore.Http;
using TravelBlogs.Core.Application.Common.Services;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.FileStorages;

namespace TravelBlogs.Core.Application.Cqrs.FileStorages.Commands;

public class UploadSingleFileCommand : IRequest<FileStorageDto>
{
    public IFormFile FileData { get; set; } = default!;

    public UploadSingleFileCommand(IFormFile fileData)
    {
        FileData = fileData;
    }
}

public class UploadSingleFileCommandHandler(
    IFileStorageService fileStorageService)
    : IRequestHandler<UploadSingleFileCommand, FileStorageDto>
{
    public async Task<FileStorageDto> Handle(UploadSingleFileCommand request, CancellationToken cancellationToken)
    {
        var fileStorageDto = await fileStorageService.UploadFileAsync(request.FileData);

        return fileStorageDto;
    }
}