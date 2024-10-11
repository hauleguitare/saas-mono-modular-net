using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonoModularNet.Module.AppNotification.Domain.EventHandler;
using MonoModularNet.Module.Shared.Common.Event;
using MonoModularNet.Module.System.Infrastructure.Mapper;

namespace MonoModularNet.Module.System.Infrastructure;

public static class Startup
{
    public static IServiceCollection AddMonoModularNetModuleSystem(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment environment)
    {
        services.AddMediatR(conf =>
        {
            conf.RegisterServicesFromAssembly(typeof(Startup).Assembly);
        });


        services.AddValidatorsFromAssembly(typeof(Startup).Assembly);

        services.AddMaps(typeof(Startup).Assembly);
        
        services.AddScoped(typeof(INotificationHandler<SystemNotificationEvent>), typeof(SystemNotificationEventHandler));
        
        return services;
    }
}