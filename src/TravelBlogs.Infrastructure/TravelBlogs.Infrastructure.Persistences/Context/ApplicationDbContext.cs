using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TravelBlogs.Core.Application.Common.Interfaces;
using TravelBlogs.Core.Domain.Entities;
using TravelBlogs.Core.Domain.Entities.Common;
using TravelBlogs.Core.Domain.Entities.Identity;

namespace TravelBlogs.Infrastructure.Persistences.Context;

public class ApplicationDbContext(
    ICurrentUser currentUser,
    ISerializerService serializer,
    IOptions<DatabaseSettings> dbSettings)
    : BaseDbContext(currentUser,
        serializer,
        dbSettings), IApplicationDbContext
{
    #region Common

    public DbSet<FileStorage> FileStorages { get; init; }
    public DbSet<Category> Categories { get; init; }

    #endregion Common

    #region Audit

    public DbSet<User> Users { get; init; }
    public DbSet<TokenRefresh> RefreshTokens { get; init; }
    public DbSet<UserRole> UserRoles { get; init; }
    public DbSet<UserVerification> UserVerifications { get; init; }
    public DbSet<Role> Roles { get; init; }

    #endregion Audit

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var decimalProps = modelBuilder.Model
            .GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => (Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType) == typeof(decimal));

        foreach (var property in decimalProps)
        {
            property.SetPrecision(18);
            property.SetScale(2);
        }

        base.OnModelCreating(modelBuilder);
    }
}