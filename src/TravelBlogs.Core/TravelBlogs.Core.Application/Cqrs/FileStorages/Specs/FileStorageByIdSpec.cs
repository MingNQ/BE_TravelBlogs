using Ardalis.Specification;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.FileStorages;
using TravelBlogs.Core.Domain.Entities.Common;

namespace TravelBlogs.Core.Application.Cqrs.FileStorages.Specs;

public sealed class FileStorageByIdSpec : Specification<FileStorage, FileStorageDto>
{
    public FileStorageByIdSpec(long id)
    {
        Query.Where(fs => fs.Id == id);
    }
}