using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        
        return services;
    }
}