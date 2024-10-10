using MediatR;
using MediatR.Pipeline;
using MonoModularNet.Infrastructure.CQRS.Event;
using MonoModularNet.Infrastructure.CQRS.ExceptionHandling;
using MonoModularNet.Infrastructure.CQRS.Mediator;
using MonoModularNet.Infrastructure.CQRS.Pipeline;
using MonoModularNet.Module.Auth.Infrastructure;

namespace MonoModularNet.WebAppBootstrapper.Bootstrapper;

public static class BootstrapMediatorExtension
{
    public static IServiceCollection AddBootstrapMediator(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment environment)
    {

        services.AddTransient(typeof(IRequestExceptionHandler<,,>), typeof(CqrsCommandExceptionHandler<,,>))
        .AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationPipeline<,>))
        .AddTransient(typeof(INotificationHandler<DomainExceptionEvent>), typeof(DomainExceptionEventHandler))
        .AddTransient<IMediatorHandler, MediatorHandler>();
        
        // services.AddMediatR(cfg =>
        // {
        //     cfg.RegisterServicesFromAssemblyContaining(typeof(Startup));
        // });
        
        return services;
    }
}