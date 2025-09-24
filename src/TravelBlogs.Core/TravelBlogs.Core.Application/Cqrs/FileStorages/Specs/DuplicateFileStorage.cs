using Ardalis.Specification;
using TravelBlogs.Core.Domain.Entities.Common;

namespace TravelBlogs.Core.Application.Cqrs.FileStorages.Specs;

public sealed class DuplicateFileStorage : Specification<FileStorage>, ISingleResultSpecification<FileStorage>
{
    public DuplicateFileStorage(string fileUniqueName, string fullPath, string fileName, string path,
        string extension) =>
        Query
            .Where(x => x.FileName == fileName)
            .Where(x => x.Path == path)
            .Where(x => x.Extension == extension)
            .Where(x => x.FileUniqueName == fileUniqueName);
}