using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelBlogs.Core.Domain.Entities.Identity;

namespace TravelBlogs.Infrastructure.Persistences.Configuration.Identity;

public class TokenRefreshConfiguration : IEntityTypeConfiguration<TokenRefresh>
{
    public void Configure(EntityTypeBuilder<TokenRefresh> builder)
    {
        builder.ToTable("RefreshTokens", SchemaNames.Identity);

        builder.HasKey(rt => rt.Id);
        
        builder.Property(rt => rt.Token).IsRequired().HasMaxLength(256);
        builder.Property(rt => rt.ExpiredDate).IsRequired();
        
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(rt => rt.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}