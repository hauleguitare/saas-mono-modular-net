namespace WebAppBootstrapper.Bootstrapper;

public static class BootstrapAuthorizationExtension
{
    public static IServiceCollection AddBootstrapAuthorization(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment environment)
    {
        services.AddAuthorization();

        return services;
    }
}