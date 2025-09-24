using Microsoft.Extensions.Options;
using TravelBlogs.Core.Application.Common.Services;
using TravelBlogs.Core.Application.Configurations;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.FileStorages;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.User;

namespace TravelBlogs.Infrastructure.Services;

public class FilePathService(IOptions<FileStorageSettings> fileStorageSettingsOptions) : IFilePathService
{
    private readonly FileStorageSettings _fileStorageSettings = fileStorageSettingsOptions.Value;

    public TDto? BindFullPaths<TDto>(TDto? dto) where TDto : class
    {
        if (dto == null)
        {
            return dto;
        }

        if (dto is FileStorageDto fileStorageDto)
        {
            string path = fileStorageDto.Path ?? string.Empty;
            fileStorageDto.FullPathUrl = GetFileStorageFullPath(path);
            return fileStorageDto as TDto;
        }

        if (dto is UserDto userDto)
        {
            userDto.Avatar = BindFullPaths(userDto.Avatar);
            return userDto as TDto;
        }

        return dto;
    }

    public List<TDto?> BindFullPaths<TDto>(List<TDto> dtos) where TDto : class
    {
        return dtos.Select(BindFullPaths).ToList();
    }

    public string GetFileStorageFullPath(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return string.Empty;
        }

        if (path.StartsWith("http://", StringComparison.Ordinal) || path.StartsWith("https://", StringComparison.Ordinal))
        {
            return path;
        }

        string baseUri = _fileStorageSettings.Uri ?? string.Empty;
        if (string.IsNullOrEmpty(baseUri))
        {
            throw new InvalidOperationException("Uri is not configured");
        }

        return baseUri + path;
    }
}