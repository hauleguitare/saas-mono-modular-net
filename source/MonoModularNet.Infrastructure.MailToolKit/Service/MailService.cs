using MailKit.Security;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using MonoModularNet.Infrastructure.MailService.Abstraction;
using MonoModularNet.Infrastructure.MailService.Model;
using MonoModularNet.Infrastructure.MailService.Setting;
using MonoModularNet.Infrastructure.Shared.Common.Attribute;

namespace MonoModularNet.Infrastructure.MailService.Service;


[Injectable(InterfaceType = typeof(IMailService), Lifetime = ServiceLifetime.Transient)]
public class MailService: IMailService
{
    private readonly ILogger<MailService> _logger;
    private readonly IOptions<MailSetting> _options;

    public MailService(ILogger<MailService> logger, IOptions<MailSetting> options)
    {
        _logger = logger;
        _options = options;
        
        ArgumentNullException.ThrowIfNull(_options.Value.Host);
        ArgumentNullException.ThrowIfNull(_options.Value.Port);
        ArgumentNullException.ThrowIfNull(_options.Value.UserName);
        ArgumentNullException.ThrowIfNull(_options.Value.Password);
    }

    public async Task SendAsync(MailContent mail, CancellationToken cancellationToken = default)
    {
        var email = new MimeMessage();

        // Sender
        email.Sender = new MailboxAddress(mail.DisplayName, mail.From);
        
        // From
        email.From.Add(new MailboxAddress(mail.DisplayName, mail.From));
        // To
        var listTo = new InternetAddressList();
        foreach (var mailToSend in mail.To)
        {
            listTo.Add(MailboxAddress.Parse(mailToSend));
        }
        email.To.AddRange(listTo);
        
        // Subject
        email.Subject = mail.Subject;

        var body = new BodyBuilder
        {
            HtmlBody = mail.Body
        };
        email.Body = body.ToMessageBody();
        
        // Smtp Client
        using var smtpClient = new MailKit.Net.Smtp.SmtpClient();
        try
        {
            await smtpClient.ConnectAsync(_options.Value.Host, _options.Value.Port, SecureSocketOptions.StartTls, cancellationToken);
            _logger.LogInformation("{0} connected SMTP Client succeed", nameof(MailService));
            
            await smtpClient.AuthenticateAsync(_options.Value.UserName, _options.Value.Password, cancellationToken);
            
            _logger.LogInformation("{0} authenticated SMTP Client succeed", nameof(MailService));
            await smtpClient.SendAsync(email, cancellationToken);
            
            _logger.LogInformation("{0} finished executed request send mail succeed", nameof(MailService));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,"{0} failed to executed request send mail", nameof(MailService));
            throw;
        }
        finally
        {
            if (smtpClient.IsConnected)
            {
                await smtpClient.DisconnectAsync(true, cancellationToken);
            }
        }
    }

    public async Task SendAsync(ICollection<string> sendTo, string subject, string html, CancellationToken cancellationToken = default)
    {
        await SendAsync(new MailContent()
        {
            To = sendTo,
            Subject = subject,
            Body = html
        }, cancellationToken);
    }

}