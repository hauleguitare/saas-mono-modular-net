using MonoModularNet.Infrastructure.MailService.Model;

namespace MonoModularNet.Infrastructure.MailService.Abstraction;

public interface IMailService
{
    public Task SendAsync(MailContent mailContent, CancellationToken cancellationToken = default);
    public Task SendAsync(ICollection<string> sendTo, string subject, string html, CancellationToken cancellationToken = default);
}