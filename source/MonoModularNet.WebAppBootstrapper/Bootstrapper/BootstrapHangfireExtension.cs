using Hangfire;
using Hangfire.PostgreSql;

namespace MonoModularNet.WebAppBootstrapper.Bootstrapper;

public static class BootstrapHangfireExtension
{
    public static IServiceCollection AddBootstrapHangfire(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        services.AddHangfire(opts =>
        {

            opts.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings();


            if (environment.IsDevelopment())
            {
                opts.UseInMemoryStorage();
            }
            else
            {
                opts.UsePostgreSqlStorage(postgreSqlOpts =>
                {
                    postgreSqlOpts.UseNpgsqlConnection(configuration.GetConnectionString("DefaultConnectionString"));
                });
            }
        });

        services.AddHangfireServer();
        return services;
    }

}