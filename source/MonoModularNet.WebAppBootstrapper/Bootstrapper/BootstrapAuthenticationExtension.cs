using Microsoft.AspNetCore.Authentication.Cookies;

namespace MonoModularNet.WebAppBootstrapper.Bootstrapper;

public static class BootstrapAuthenticationExtension
{
    public static IServiceCollection AddBootstrapAuthentication(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment environment)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie();
        
        return services;
    }
}