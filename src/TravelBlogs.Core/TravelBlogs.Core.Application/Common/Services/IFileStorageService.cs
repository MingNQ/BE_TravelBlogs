using Microsoft.AspNetCore.Http;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.FileStorages;

namespace TravelBlogs.Core.Application.Common.Services;

public interface IFileStorageService
{
    Task<FileStorageDto> UploadFileAsync(IFormFile file);
    Task<FileStorageDto> CreateFileStorageFromUrlAsync(string url);
}