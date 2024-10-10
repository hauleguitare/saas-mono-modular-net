using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MonoModularNet.Module.Auth.Infrastructure.Mapper;

internal static class MapperConfig
{
    internal static IServiceCollection AddMaps(this IServiceCollection services, Assembly assembly)
    {
        services.AddAutoMapper(opts => opts.AddMaps(assembly));
        return services;
    }
}