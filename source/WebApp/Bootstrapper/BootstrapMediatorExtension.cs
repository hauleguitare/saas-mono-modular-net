using Infrastructure.CQRS.Command;

namespace WebApp.Bootstrapper;

public static class BootstrapMediatorExtension
{
    public static IServiceCollection AddBootstrapMediator(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment environment)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });
        
        return services;
    }
}