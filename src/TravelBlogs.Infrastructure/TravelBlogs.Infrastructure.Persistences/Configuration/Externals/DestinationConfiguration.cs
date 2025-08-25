using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelBlogs.Core.Domain.Entities.Geo;

namespace TravelBlogs.Infrastructure.Persistences.Configuration.Externals;

public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
{
    public void Configure(EntityTypeBuilder<Destination> builder)
    {
        builder.ToTable("Destinations", SchemaNames.External);

        builder
            .HasOne(d => d.Country)
            .WithMany(c => c.Destinations)
            .HasForeignKey(d => d.CountryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}