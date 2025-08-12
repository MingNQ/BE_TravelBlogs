using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelBlogs.Core.Domain.Entities.Common;

namespace TravelBlogs.Infrastructure.Persistences.Configuration.Common;

public class FileStorageConfiguration : IEntityTypeConfiguration<FileStorage>
{
    public void Configure(EntityTypeBuilder<FileStorage> builder)
    {
        builder.ToTable("FileStorages", SchemaNames.Common);
    }
}