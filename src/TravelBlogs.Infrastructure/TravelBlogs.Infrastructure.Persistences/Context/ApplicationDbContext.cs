using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TravelBlogs.Core.Application.Common.Interfaces;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Domain.Entities.Common;
using TravelBlogs.Core.Domain.Entities.Geo;
using TravelBlogs.Core.Domain.Entities.Identity;

namespace TravelBlogs.Infrastructure.Persistences.Context;

public class ApplicationDbContext(
    ICurrentUser currentUser,
    ISerializerService serializer,
    IOptions<DatabaseSettings> dbSettings)
    : BaseDbContext(currentUser,
        serializer,
        dbSettings)
{
    #region Common

    public DbSet<FileStorage> FileStorages => Set<FileStorage>();

    #endregion Common

    #region Audit

    public DbSet<User> Users => Set<User>();
    public DbSet<TokenRefresh> RefreshTokens => Set<TokenRefresh>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<UserVerification> UserVerifications => Set<UserVerification>();
    public DbSet<Role> Roles => Set<Role>();

    #endregion Audit

    #region Externals
    public DbSet<Country> Countries => Set<Country>(); 
    public DbSet<Destination> Destinations => Set<Destination>();
    #endregion

    #region Catalog
    public DbSet<Faq> FAQs => Set<Faq>();
    public DbSet<ContactInformation> ContactsInformation => Set<ContactInformation>();
    public DbSet<Contact> Contacts => Set<Contact>();

    #endregion Catalog

    protected override void OnModelCreating(ModelBuilder modelBuilder)

    {
        var decimalProps = modelBuilder.Model
            .GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => (System.Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType) == typeof(decimal));

        foreach (var property in decimalProps)
        {
            property.SetPrecision(18);
            property.SetScale(2);
        }

        base.OnModelCreating(modelBuilder);
    }
}