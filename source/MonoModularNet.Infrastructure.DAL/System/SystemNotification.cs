using Core.Common.Entity;
using Core.Entity;

namespace MonoModularNet.Infrastructure.DAL.Notification;

public class SystemNotification: BaseEntity<string>, IAggregateRoot
{
    public SystemNotification()
    {
        
    }
    
    public SystemNotification(string userId, string content, DateTime notifiedAt, string? from)
    {
        Id = Guid.NewGuid().ToString("N");
        NotifiedAt = notifiedAt;
        UserId = userId;
        Content = content;
        From = from;
    }

    public string Id { get; set; } = null!;
    public string? Content { get; set; }
    public string? From { get; set; }
    public DateTime NotifiedAt { get; set; }
    
    public string UserId { get; set; }
}