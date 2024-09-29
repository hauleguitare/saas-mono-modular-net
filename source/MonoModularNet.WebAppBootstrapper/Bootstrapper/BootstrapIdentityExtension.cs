using MonoModularNet.Infrastructure.DAL.Context;
using MonoModularNet.Infrastructure.DAL.Identity;
using Microsoft.AspNetCore.Identity;

namespace MonoModularNet.WebAppBootstrapper.Bootstrapper;

public static class BootstrapIdentityExtension
{
    public static IServiceCollection AddBootstrapIdentity(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment environment)
    {
        services.AddIdentityCore<ApplicationUser>(opts =>
            {
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();
        
        return services;
    }
}