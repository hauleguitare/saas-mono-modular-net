using System.Reflection;
using Infrastructure.DAL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Common.Attribute;
using SharedKernel.Common.Struct;

namespace WebApp.Bootstrapper;

public static class ApiBoostrapHelper
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        // Add services to the container.
        services.AddControllers();
        
        // Add Authorization Ccore
        services.AddAuthorization();

        services.AddIdentityApiEndpoints<IdentityUser>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        // Configure dependency injection
        ConfigureDependencyInjection(services);
        
        // Database
        services.AddDbContext<ApplicationDbContext>(
            opts =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                opts.UseNpgsql(connectionString);

                if (environment.IsDevelopment())
                {
                    opts.EnableSensitiveDataLogging();
                    opts.EnableDetailedErrors();
                }
            });
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

        app.MapIdentityApi<IdentityUser>();

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