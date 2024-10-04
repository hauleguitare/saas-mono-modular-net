using MonoModularNet.Infrastructure.MailService.Setting;

namespace MonoModularNet.WebAppBootstrapper.Bootstrapper;

public static class BootstrapMailExtension
{
    public static IServiceCollection AddBootstrapMail(this IServiceCollection services, IConfiguration configuration,
        IWebHostEnvironment environment)
    {
        services.AddOptions<MailSetting>()
            .BindConfiguration(nameof(MailSetting))
            .ValidateDataAnnotations()
            .ValidateOnStart();


        return services;
    }
}