using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonoModularNet.Infrastructure.CQRS;

namespace MonoModularNet.Module.Auth.Infrastructure;

public static class Startup
{
    public static IServiceCollection AddMonoModularNetModuleAuth(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment environment)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Startup).Assembly);
        });
        
        services.AddMonoModularNetCqrs();
        return services;
    }
}