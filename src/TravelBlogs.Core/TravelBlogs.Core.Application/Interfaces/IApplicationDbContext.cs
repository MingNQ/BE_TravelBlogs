using Microsoft.EntityFrameworkCore;
using TravelBlogs.Core.Domain.Entities;
using TravelBlogs.Core.Domain.Entities.Common;
using TravelBlogs.Core.Domain.Entities.Identity;

namespace TravelBlogs.Core.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<FileStorage> FileStorages { get; }
    DbSet<User> Users { get; }
    DbSet<TokenRefresh> RefreshTokens { get; }
    DbSet<UserRole> UserRoles { get; }
    DbSet<UserVerification> UserVerifications { get; }
    DbSet<Role> Roles { get; }

    DbSet<Category> Categories { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}