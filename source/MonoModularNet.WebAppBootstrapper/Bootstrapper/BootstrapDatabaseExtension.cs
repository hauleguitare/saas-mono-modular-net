using Microsoft.EntityFrameworkCore;
using MonoModularNet.Infrastructure.DAL.Context;
using MonoModularNet.Infrastructure.DAL.Hasher;
using MonoModularNet.Infrastructure.DAL.Identity;
using MonoModularNet.Infrastructure.DAL.Repository;
using MonoModularNet.Infrastructure.DAL.UnitOfWork;

namespace MonoModularNet.WebAppBootstrapper.Bootstrapper;

public static class BootstrapDatabaseExtension
{
    public static IServiceCollection AddBootstrapDbContext(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment environment)
    {
        // Add Db Context
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


        // Add Unit Of Work
        services.AddUnitOfWork<ApplicationDbContext>();
        
        // Add ASP.NET Core Identity
        services.AddBootstrapIdentity(configuration, environment);
        
        // Add Application User Password Hasher
        services.AddTransient(typeof(IApplicationPasswordHasher), typeof(ApplicationPasswordHasher));
        
        // Add Dapper Context
        services.AddScoped(typeof(IDapperContext), typeof(DapperContext));

        return services;
    }


    /// <summary>
    /// Add Unit Of Work Pattern into services.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="lifetime"></param>
    /// <typeparam name="TContext"></typeparam>
    /// <returns></returns>
    private static IServiceCollection AddUnitOfWork<TContext>(
        this IServiceCollection services,
        ServiceLifetime lifetime = ServiceLifetime.Scoped
        ) where TContext : DbContext
    {
        switch (lifetime)
        {
            case ServiceLifetime.Scoped:
                services.AddScoped(typeof(IUnitOfWork), provider =>
                {
                    var ctx = provider.GetRequiredService<TContext>();
                    return new UnitOfWork(ctx);
                });
                break;
            
            case ServiceLifetime.Transient:
                services.AddScoped(typeof(IUnitOfWork), provider =>
                {
                    var ctx = provider.GetRequiredService<TContext>();
                    return new UnitOfWork(ctx);
                });
                break;
            
            case ServiceLifetime.Singleton:
                services.AddScoped(typeof(IUnitOfWork), provider =>
                {
                    var ctx = provider.GetRequiredService<TContext>();
                    return new UnitOfWork(ctx);
                });
                break;
        }

        return services;
    }

    /// <summary>
    /// Add Entity Repository into services
    /// </summary>
    /// <param name="services"></param>
    /// <param name="lifetime"></param>
    /// <typeparam name="TContext"></typeparam>
    /// <returns></returns>
    private static IServiceCollection AddEntityRepository<TContext>(this IServiceCollection services,
        ServiceLifetime lifetime = ServiceLifetime.Scoped) where TContext : DbContext
    {
        var repoType = typeof(IEntityRepository<,>);
        return services;
    }
    
    private static IServiceCollection AddBootstrapIdentity(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment environment)
    {
        services.AddIdentityCore<ApplicationUser>(opts =>
            {
            })
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        
        return services;
    }
}