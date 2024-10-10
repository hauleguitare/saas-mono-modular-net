using Microsoft.EntityFrameworkCore;
using MonoModularNet.Infrastructure.DAL.Hasher;
using MonoModularNet.Infrastructure.DAL.Identity;

namespace MonoModularNet.Infrastructure.DAL.Seed;

internal static class ApplicationUserSeedExtension
{
    public static ModelBuilder SeedApplicationUser(this ModelBuilder builder, string email, string password)
    {
        var applicationPasswordHasher = new ApplicationPasswordHasher();

        var rootAdmin = new ApplicationUser()
        {
            Id = "owner",
            Email = email,
            EmailConfirmed = true,
            UserName = email,
            NormalizedUserName = email.ToUpper(),
            NormalizedEmail = email.ToUpper()
        };
        var passwordHashed = applicationPasswordHasher.HashPassword(rootAdmin, password);

        rootAdmin.PasswordHash = passwordHashed;

        builder.Entity<ApplicationUser>().HasData(rootAdmin);

        return builder;
    }
}