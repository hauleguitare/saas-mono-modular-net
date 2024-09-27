using Infrastructure.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Bootstrapper;

public static class BootstrapDatabaseExtension
{
    public static IServiceCollection AddBootstrapDbContext(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment environment)
    {
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

        return services;
    }
}