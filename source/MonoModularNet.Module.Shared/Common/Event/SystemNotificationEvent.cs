using MonoModularNet.Infrastructure.CQRS.Event;

namespace MonoModularNet.Module.Shared.Common.Event;

public class SystemNotificationEvent: DomainEvent
{
    public SystemNotificationEvent(string userId, string content, string? from)
    {
        UserId = userId;
        From = from;
        Content = content;
        NotifiedAt = DateTime.UtcNow;
    }

    public string Content { get; set; }
    public string? From { get; set; }
    public DateTime NotifiedAt { get; set; }
    public string UserId { get; set; }
}