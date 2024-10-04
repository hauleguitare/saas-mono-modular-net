using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MonoModularNet.Module.Auth.Infrastructure;

public static class Startup
{
    public static IServiceCollection AddMonoModularNetModuleAuth(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment environment)
    {
        return services;
    }
}