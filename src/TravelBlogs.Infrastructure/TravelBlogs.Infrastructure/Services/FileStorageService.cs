using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Mapster;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.Services;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Configurations;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.FileStorages;
using TravelBlogs.Core.Domain.Entities.Common;

namespace TravelBlogs.Infrastructure.Services;

public class FileStorageService(
    IUnitOfWork unitOfWork,
    IWebHostEnvironment environment,
    IFilePathService filePathService,
    IOptions<FileStorageSettings> fileStorageSettingsOptions) : IFileStorageService
{
    private readonly FileStorageSettings _fileStorageSettings = fileStorageSettingsOptions.Value;
    private readonly IWriteRepository<FileStorage> _fileStorageRepository = unitOfWork.GetRepository<FileStorage>();

    public Task<FileStorageDto> CreateFileStorageFromUrlAsync(string url)
    {
        throw new NotImplementedException();
    }

    public async Task<FileStorageDto> UploadFileAsync(IFormFile file)
    {
        FileUploadValidate(file);

        string uploadFolder = _fileStorageSettings.FullPath;
        string basePath = _fileStorageSettings.Path;

        string contentRoot = environment.WebRootPath ?? environment.ContentRootPath;
        uploadFolder = Path.Combine(contentRoot, basePath.TrimStart('/'));

        if (!Directory.Exists(uploadFolder))
        {
            Directory.CreateDirectory(uploadFolder);
        }

        if (string.IsNullOrWhiteSpace(uploadFolder))
        {
            throw new BadHttpRequestException("FullPath is not configured.");
        }

        string uniqueFileName = HandleUniqueFileName(Path.GetFileNameWithoutExtension(file.FileName), Path.GetExtension(file.FileName).ToLowerInvariant());

        var now = DateTime.UtcNow;
        string year = now.Year.ToString();
        string month = now.Month.ToString("D2");

        string relativePath = Path.Combine(year, month);
        string fullDirectoryPath = Path.Combine(uploadFolder, relativePath);

        Directory.CreateDirectory(fullDirectoryPath);

        string filePath = Path.Combine(fullDirectoryPath, uniqueFileName);

        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        string dbPath = $"{basePath}/{relativePath}/".Replace("\\", "/");

        var result = await CreateFileStorageAsync(file, uniqueFileName, dbPath);

        filePathService.BindFullPaths(result);

        return result;
    }

    private async Task<FileStorageDto> CreateFileStorageAsync(IFormFile? file, string uniqueFileName, string path)
    {
        var fileStorage = FileStorage.Create(
            file?.FileName,
            uniqueFileName,
            file?.Length,
            file?.ContentType,
            $"{path}/{uniqueFileName}",
            Path.GetExtension(file?.FileName));

        var result = await _fileStorageRepository.InsertAsync(fileStorage);
        await unitOfWork.SaveChangesAsync();

        return result.Entity.Adapt<FileStorageDto>();
    }

    private void FileUploadValidate(IFormFile file)
    {
        if (file.Length == 0)
        {
            throw new BadHttpRequestException("No file uploaded.");
        }

        // Validate file size (5MB limit)
        const long MAX_FILE_SIZE = 5 * 1024 * 1024;
        if (file.Length > MAX_FILE_SIZE)
        {
            throw new BadHttpRequestException("File size exceeds 5MB limit.");
        }

        string[] allowedTypes = ["image/jpeg", "image/jpg", "image/png", "image/webp"];
        if (!allowedTypes.Contains(file.ContentType))
        {
            throw new BadHttpRequestException("Only JPG, PNG, and WebP image files are alowed");
        }
    }

    private string HandleUniqueFileName(string fileName, string extension)
    {
        string normalized = fileName.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();

        foreach (var c in normalized)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(c);
            }
        }

        // Eliminate mark
        string noDiacritics = sb.ToString().Normalize(NormalizationForm.FormC);

        string safeName = Regex.Replace(noDiacritics, @"[^a-z0-9]+", "-");

        safeName = safeName.Trim('-');

        string datePart = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();

        string uniqueFileName = $"{safeName}-{datePart}{extension}";

        return uniqueFileName;
    }
}