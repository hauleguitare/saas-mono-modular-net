using FluentValidation;
using MonoModularNet.Module.Auth.Infrastructure;

namespace MonoModularNet.WebAppBootstrapper.Bootstrapper;

public static class BootstrapValidatorExtension
{
    public static IServiceCollection AddBootstrapValidation(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        // services.AddValidatorsFromAssemblyContaining(typeof(Startup));

        return services;
    }
}