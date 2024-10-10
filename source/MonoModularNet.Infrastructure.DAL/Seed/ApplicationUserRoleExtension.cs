using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MonoModularNet.Infrastructure.DAL.Identity;

namespace MonoModularNet.Infrastructure.DAL.Seed;

internal static class ApplicationUserRoleExtension
{
    public static ModelBuilder SeedApplicationUserRole(this ModelBuilder modelBuilder, string userId, string roleId)
    {
        var userRole = new IdentityUserRole<string>()
        {
            UserId = userId,
            RoleId = roleId,
        };

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRole);
        return modelBuilder;
    }
}