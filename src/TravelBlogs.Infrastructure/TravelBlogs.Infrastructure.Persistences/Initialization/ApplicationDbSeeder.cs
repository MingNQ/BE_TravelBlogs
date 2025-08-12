using Microsoft.EntityFrameworkCore;
using TravelBlogs.Core.Application.Utility;
using TravelBlogs.Core.Domain.Entities.Identity;
using TravelBlogs.Core.Shared.Constants;
using TravelBlogs.Infrastructure.Persistences.Context;

namespace TravelBlogs.Infrastructure.Persistences.Initialization;

public class ApplicationDbSeeder(CustomSeederRunner seederRunner)
{
    public async Task SeedDatabaseAsync(ApplicationDbContext dbContext, CancellationToken cancellationToken)
    {
        await seederRunner.RunSeedersAsync(cancellationToken);
        await SeedRolesAsync(dbContext);
        await SeedUserDataAsync(dbContext);
    }

    private async Task SeedRolesAsync(ApplicationDbContext dbContext)
    {
        // Create roles if they don't exist
        var roles = new[]
        {
            Role.Create(AppConsts.AdminRoleName),
            Role.Create(AppConsts.ManagerRoleName),
            Role.Create(AppConsts.UserNormalRoleName)
        };

        foreach (var role in roles)
        {
            if (await dbContext.Roles.CountAsync(r => r.NormalizedName == role.NormalizedName) == 0)
            {
                await dbContext.Roles.AddAsync(role);
            }
        }

        await dbContext.SaveChangesAsync();
    }

    private async Task SeedUserDataAsync(ApplicationDbContext dbContext)
    {
        var user = new User(AppConsts.AdminUserName, AppConsts.AdminEmail, AppConsts.AdminFirstName, AppConsts.AdminLastName);
        //user.SetAvatar("/uploads/common/images/user-default.png");
        string passwordHash = Utils.ComputeHash(AppConsts.AdminPassword);
        user.VerifyEmail();
        user.SetPassword(passwordHash);

        if ((await dbContext.Users.CountAsync(x => x.UserName == user.UserName)) == 0)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            // Assign Admin role to the admin user
            await AssignRoleToUserAsync(dbContext, user.Id, AppConsts.AdminRoleName);
        }
    }

    private async Task AssignRoleToUserAsync(ApplicationDbContext dbContext, long userId, string roleName)
    {
        // Get role ID
        var role = await dbContext.Roles.FirstOrDefaultAsync(r => r.Name == roleName);

        if (role != null && await dbContext.UserRoles.CountAsync(ur => ur.UserId == userId && ur.RoleId == role.Id) == 0)
        {
            // Check if the user already has this role Create new user role assignment
            var userRole = new UserRole
            {
                UserId = userId,
                RoleId = role.Id
            };

            await dbContext.UserRoles.AddAsync(userRole);
            await dbContext.SaveChangesAsync();
        }
    }
}