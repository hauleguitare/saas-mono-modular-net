using Microsoft.EntityFrameworkCore;
using MonoModularNet.Infrastructure.DAL.Identity;

namespace MonoModularNet.Infrastructure.DAL.Seed;

internal static class ApplicationRoleSeedExtension
{
    public static ModelBuilder SeedApplicationRoles(this ModelBuilder builder)
    {
        var roles = new List<ApplicationRole>()
        {
            new ()
            {
                Id = "owner",
                Name = "Owner",
                NormalizedName = "Owner".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Priority = 0
            },
            new ()
            {
                Id = "administrator",
                Name = "Administrator",
                NormalizedName = "Administrator".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Priority = 1
            },
            new ()
            {
                Id = "moderator",
                Name = "Moderator",
                NormalizedName = "Moderator".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Priority = 2
            },
            new ()
            {
                Id = "user",
                Name = "User",
                NormalizedName = "User".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Priority = 3
            }
        };

        builder.Entity<ApplicationRole>().HasData(roles);

        return builder;
    }
}