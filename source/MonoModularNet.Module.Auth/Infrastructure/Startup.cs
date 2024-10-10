using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonoModularNet.Module.Auth.Domain.SignUp.Command;
using MonoModularNet.Module.Auth.Infrastructure.Mapper;

namespace MonoModularNet.Module.Auth.Infrastructure;

public static class Startup
{
    public static IServiceCollection AddMonoModularNetModuleAuth(this IServiceCollection services,
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