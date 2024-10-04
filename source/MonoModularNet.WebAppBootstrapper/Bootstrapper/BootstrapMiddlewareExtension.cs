using MonoModularNet.WebAppBootstrapper.Middleware;

namespace MonoModularNet.WebAppBootstrapper.Bootstrapper;

public static class BootstrapMiddlewareExtension
{
    public static IServiceCollection AddBootstrapMiddleware(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment environment)
    {
        return services.AddScoped<HostExceptionMiddleware>();
    }
}