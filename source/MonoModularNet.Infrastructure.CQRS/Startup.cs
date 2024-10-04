using Microsoft.Extensions.DependencyInjection;
using MonoModularNet.Infrastructure.CQRS.Mediator;

namespace MonoModularNet.Infrastructure.CQRS;

public static class Startup
{
    public static IServiceCollection AddMonoModularNetCqrs(this IServiceCollection services)
    {
        return services.AddTransient<IMediatorHandler, MediatorHandler>();
    }
}