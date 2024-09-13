using System.Reflection;
using WebApp.Common.Utils;

namespace WebApp.Common.Helper;

public static class ApiBoostrapHelper
{
    public static void ConfigureServices(IServiceCollection services)
    {
        // Add services to the container.
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
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
    }

    public static void ConfigureDependencyInjection(IServiceCollection services)
    {
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes()).ToList();

        var injectableServiceObjects = types
            .Where(t => t.IsInterface && t.IsDefined(typeof(InjectableAttribute), false))
            .Select(t => new InjectableServiceObject()
            {
                Interface = t,
                Lifetime = t.GetCustomAttribute<InjectableAttribute>()?.Lifetime ?? ServiceLifetime.Transient,
            }).ToList();


        for (int i = 0; i < injectableServiceObjects.Count; i++)
        {
            var injectableObj = injectableServiceObjects[i];

            injectableObj.Implementation = types.FirstOrDefault(t => t is { IsClass: true, IsAbstract: false } && t.IsAssignableTo(injectableObj.Interface));
        }
    }
    
    
    public static void AddService(this IServiceCollection services, Type iType, Type implType,
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
    
    public struct InjectableServiceObject
    {
        public Type? Interface { get; set; }
        public Type? Implementation { get; set; }
        public ServiceLifetime? Lifetime { get; set; }
        
        public InjectableServiceObject(
            
            ) {}
    }
}