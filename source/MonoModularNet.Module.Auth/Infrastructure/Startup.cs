using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonoModularNet.Module.Auth.Domain.SignUp.Command;

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
        
        return services;
    }
}