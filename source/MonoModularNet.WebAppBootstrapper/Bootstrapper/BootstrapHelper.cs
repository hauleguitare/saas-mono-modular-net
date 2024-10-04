using System.Reflection;
using Hangfire;
using MonoModularNet.Infrastructure.Shared.Common.Attribute;
using MonoModularNet.WebAppBootstrapper.Middleware;

namespace MonoModularNet.WebAppBootstrapper.Bootstrapper;

public static class ApiBootstrapHelper
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        // Add services to the container.
        services.AddControllers();
        
        // Add Authorization Ccore
        services.AddBootstrapAuthorization(configuration, environment);

        // Add Identity
        services.AddBootstrapIdentity(configuration, environment);
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        // Add Host Exception Middleware
        services.AddBootstrapMiddleware(configuration, environment);
        
        // Database
        services.AddBootstrapDbContext(configuration, environment);
        
        // Mediator
        services.AddBootstrapMediator(configuration, environment);
        
        // Hangfire
        services.AddBootstrapHangfire(configuration, environment);
        
        // Redis cache
        services.AddBootstrapCache(configuration, environment);
        
        // Mail
        services.AddBootstrapMail(configuration, environment);
        
        // Validation
        services.AddBootstrapValidation(configuration, environment);
        
        // MonoModular Modules
        services.AddBootstrapMonoModularNetModule(configuration, environment);
        
        // Configure dependency injection
        ConfigureDependencyInjection(services);
    }

    public static void RegisterMiddlewares(WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        // app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.UseHangfireDashboard("/jobs");

        app.UseMiddleware<HostExceptionMiddleware>();

        app.MapControllers();
    }

    public static void ConfigureDependencyInjection(IServiceCollection services)
    {
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes()).ToList();

        var injectableServices = types
            .Where(t => t.IsDefined(typeof(InjectableAttribute), true))
            .Select(t => new InjectableServiceObject()
            {
                Implementation = t,
                Interface = t.GetCustomAttribute<InjectableAttribute>()?.InterfaceType,
                Lifetime = t.GetCustomAttribute<InjectableAttribute>()?.Lifetime ?? ServiceLifetime.Transient,
            }).ToList();


        foreach (var injectableService in injectableServices)
        {
            ArgumentNullException.ThrowIfNull(injectableService.Interface);
            ArgumentNullException.ThrowIfNull(injectableService.Implementation);
            ArgumentNullException.ThrowIfNull(injectableService.Lifetime);
           
            services.AddBootstrapService(
                iType: injectableService.Interface, 
                implType: injectableService.Implementation,
                lifetime: injectableService.Lifetime.Value);
        }
    }

    private static void AddBootstrapService(this IServiceCollection services, Type iType, Type implType,
        ServiceLifetime lifetime)
    {
        switch (lifetime)
        {
            case ServiceLifetime.Transient:
                services.AddTransient(iType, implType);
                break;
            
            case ServiceLifetime.Scoped:
                services.AddScoped(iType, implType);
                break;
            
            case ServiceLifetime.Singleton:
                services.AddSingleton(iType, implType);
                break;
            
            
            default:
                throw new ArgumentException("Invalid lifetime", nameof(lifetime));
        }
    }
}