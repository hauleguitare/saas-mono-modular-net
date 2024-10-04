using MediatR.Pipeline;
using MonoModularNet.Infrastructure.CQRS.ExceptionHandling;
using MonoModularNet.Infrastructure.CQRS.Mediator;
using MonoModularNet.Module.Auth.Infrastructure;

namespace MonoModularNet.WebAppBootstrapper.Bootstrapper;

public static class BootstrapMediatorExtension
{
    public static IServiceCollection AddBootstrapMediator(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment environment)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining(typeof(Startup));
        });

        services.AddTransient(typeof(IRequestExceptionHandler<,,>), typeof(CqrsRequestExceptionHandler<,,>))
        .AddTransient<IMediatorHandler, MediatorHandler>();
        
        return services;
    }
}