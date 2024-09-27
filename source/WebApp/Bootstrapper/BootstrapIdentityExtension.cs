using Infrastructure.DAL.Context;
using Infrastructure.DAL.Identity;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Bootstrapper;

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