using MonoModularNet.Infrastructure.DAL.Notification;

namespace MonoModularNet.Module.System.Domain.GetNotification;

public class GetNotificationQuery: CqrsQuery<ICollection<SystemNotification>>
{
    
}