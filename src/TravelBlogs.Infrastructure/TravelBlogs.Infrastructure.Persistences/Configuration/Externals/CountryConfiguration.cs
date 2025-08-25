using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelBlogs.Core.Domain.Entities.Geo;

namespace TravelBlogs.Infrastructure.Persistences.Configuration.Externals;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries", SchemaNames.External);

        builder.HasMany(x => x.Cities)
            .WithOne(d => d.Country)
            .HasForeignKey(d => d.CountryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
