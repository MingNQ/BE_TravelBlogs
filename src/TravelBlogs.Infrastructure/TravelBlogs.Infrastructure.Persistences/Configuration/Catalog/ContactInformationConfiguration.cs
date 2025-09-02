using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Infrastructure.Persistences.Configuration.Catalog;

public class ContactInformationConfiguration : IEntityTypeConfiguration<ContactInformation>
{
    public void Configure(EntityTypeBuilder<ContactInformation> builder)
    {
        builder.ToTable("ContactsInformation", SchemaNames.Catalog);
    }
}