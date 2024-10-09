using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MonoModularNet.Module.System.Infrastructure.Mapper;

public static class MapperConfig
{
    public static IServiceCollection AddMaps(this IServiceCollection services, Assembly assembly)
    {
        services.AddAutoMapper(opts => opts.AddMaps(assembly));
        return services;
    }
}