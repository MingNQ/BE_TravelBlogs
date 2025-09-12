using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Infrastructure.Persistences.Configuration.Catalog;

public class BlogAttachmentConfiguration : IEntityTypeConfiguration<BlogAttachment>
{
    public void Configure(EntityTypeBuilder<BlogAttachment> builder)
    {
        builder.ToTable("BlogAttachments", SchemaNames.Catalog);

        builder
            .HasOne(x => x.FileStorage)
            .WithMany()
            .HasForeignKey(x => x.FileStorageId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.Blog)
            .WithMany()
            .HasForeignKey(x => x.BlogId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}