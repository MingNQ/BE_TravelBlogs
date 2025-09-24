using MediatR;
using Microsoft.AspNetCore.Http;
using TravelBlogs.Core.Application.Common.Services;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.FileStorages;

namespace TravelBlogs.Core.Application.Cqrs.FileStorages.Commands;

public class UploadMultipleFileCommand : IRequest<IList<FileStorageDto>>
{
    public IReadOnlyList<IFormFile> Files { get; set; } = [];
}

public class UploadMultipleFileCommandHandler(IFileStorageService fileStorageService)
    : IRequestHandler<UploadMultipleFileCommand, IList<FileStorageDto>>
{
    public async Task<IList<FileStorageDto>> Handle(UploadMultipleFileCommand request, CancellationToken cancellationToken)
    {
        var fileStorages = new List<FileStorageDto>();

        foreach (var file in request.Files)
        {
            var fileStorageDto = await fileStorageService.UploadFileAsync(file);
            fileStorages.Add(fileStorageDto);
        }

        return fileStorages;
    }
}