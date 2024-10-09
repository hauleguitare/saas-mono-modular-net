
using MonoModularNet.Module.Auth.Infrastructure;
using MonoModularNet.Module.System.Infrastructure;

namespace MonoModularNet.WebAppBootstrapper.Bootstrapper;

public static class BootstrapMonoModularNetModuleExtension
{
    public static IServiceCollection AddBootstrapMonoModularNetModule(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment environment)
    {
        // Mono Modular Auth
        services.AddMonoModularNetModuleAuth(configuration, environment)
            .AddMonoModularNetModuleSystem(configuration, environment);
        
        
        
        return services;
    }
}