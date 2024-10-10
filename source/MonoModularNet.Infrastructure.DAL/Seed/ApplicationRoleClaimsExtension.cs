using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MonoModularNet.Infrastructure.DAL.Seed;

internal static class ApplicationRoleClaimsExtension
{
    public static ModelBuilder SeedApplicationRoleClaims(this ModelBuilder modelBuilder)
    {
        var roleClaims = new List<IdentityRoleClaim<string>>()
        {
            new()
            {
                Id = 1,
                RoleId = "owner",
                ClaimType = "EnvironmentPermission",
                ClaimValue = "Add"
            },
            new()
            {
                Id = 2,
                RoleId = "owner",
                ClaimType = "EnvironmentPermission",
                ClaimValue = "PatchUpdate"
            },
            new()
            {
                Id = 3,
                RoleId = "owner",
                ClaimType = "EnvironmentPermission",
                ClaimValue = "Delete"
            }
        };

        modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);

        return modelBuilder;
    }
}