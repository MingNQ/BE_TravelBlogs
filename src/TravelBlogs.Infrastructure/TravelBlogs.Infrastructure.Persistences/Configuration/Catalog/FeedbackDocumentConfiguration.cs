using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Infrastructure.Persistences.Configuration.Catalog;

public class FeedbackDocumentConfiguration : IEntityTypeConfiguration<FeedbackDocument>
{
    public void Configure(EntityTypeBuilder<FeedbackDocument> builder)
    {
        builder.ToTable("FeedbackDocuments", SchemaNames.Catalog);

        builder
            .HasOne(x => x.FileStorage)
            .WithMany()
            .HasForeignKey(x => x.FileStorageId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.Feedback)
            .WithMany(x => x.FeedbackDocuments)
            .HasForeignKey(x => x.FeedbackId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}




