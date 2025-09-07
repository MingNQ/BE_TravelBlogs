using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Infrastructure.Persistences.Configuration.Catalog;

public class FaqConfiguration : IEntityTypeConfiguration<Faq>
{
    public void Configure(EntityTypeBuilder<Faq> builder)
    {
        builder.ToTable("Faqs", SchemaNames.Catalog);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Question).IsRequired().HasMaxLength(500);   
        builder.Property(x => x.Answer).IsRequired().HasMaxLength(2000);
        builder.HasIndex(x => x.Question);
    }
}