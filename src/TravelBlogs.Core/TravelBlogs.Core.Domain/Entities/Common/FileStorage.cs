using System.ComponentModel.DataAnnotations;
using TravelBlogs.Core.Domain.Common.Contracts;
using TravelBlogs.Core.Shared.Enums;

namespace TravelBlogs.Core.Domain.Entities.Common;

public class FileStorage : AuditableEntity<long>
{
    [MaxLength(255)]
    public string? FileName { get; set; }

    [MaxLength(255)]
    public string? FileUniqueName { get; set; }

    public decimal? Size { get; set; }

    [MaxLength(255)]
    public string? Type { get; set; }

    [MaxLength(255)]
    public string? Path { get; set; }

    [MaxLength(255)]
    public string? Extension { get; set; }

    public FileStorageStatus Status { get; set; }

    public static FileStorage Create(string? fileName, string? fileUniqueName, decimal? size,
        string? type, string? path, string? extension)
    {
        return new FileStorage
        {
            FileName = fileName,
            FileUniqueName = fileUniqueName,
            Size = size,
            Type = type,
            Path = path,
            Extension = extension,
            Status = FileStorageStatus.Draft
        };
    }

    public void Update(string? fileName, string? fileUniqueName, decimal? size, string? type,
        string? path, string? extension)
    {
        FileName = fileName;
        FileUniqueName = fileUniqueName;
        Size = size;
        Type = type;
        Path = path;
        Extension = extension;
    }

    public void UpdateStatus(FileStorageStatus status)
    {
        Status = status;
    }
}