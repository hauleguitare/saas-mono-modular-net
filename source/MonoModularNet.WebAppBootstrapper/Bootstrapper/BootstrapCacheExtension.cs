using MonoModularNet.Infrastructure.Cache.Setting;

namespace MonoModularNet.WebAppBootstrapper.Bootstrapper;

public static class BootstrapCacheExtension
{
    public static IServiceCollection AddBootstrapCache(this IServiceCollection services, IConfiguration configuration,
        IWebHostEnvironment environment)
    {
        services.AddOptions<CacheSetting>()
            .BindConfiguration(nameof(CacheSetting))
            .ValidateDataAnnotations()
            .ValidateOnStart();
        
        var setting = new CacheSetting();
        configuration.GetSection(nameof(CacheSetting)).Bind(setting);
        
        services.AddStackExchangeRedisCache(opts =>
        {
            opts.Configuration = setting.ConnectionString;
            opts.InstanceName = setting.InstanceName;
        });
        
        return services;
    }
}