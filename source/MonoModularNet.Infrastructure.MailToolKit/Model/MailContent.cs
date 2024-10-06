namespace MonoModularNet.Infrastructure.MailService.Model;

public class MailContent
{
    public string? From { get; set; }
    public string? DisplayName { get; set; }
    public ICollection<string> To { get; set; } = new List<string>();
    public string? Subject { get; set; }
    public string? Body { get; set; }
}
