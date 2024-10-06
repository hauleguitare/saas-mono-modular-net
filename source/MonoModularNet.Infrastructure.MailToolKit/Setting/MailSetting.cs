namespace MonoModularNet.Infrastructure.MailService.Setting;

public class MailSetting
{
    public string Host { get; set; } = null!;
    public int Port { get; set; }

    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}