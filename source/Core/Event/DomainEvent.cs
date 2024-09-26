using SharedKernel.Common.Event;

namespace Core.Event;

public class DomainEvent: IEvent
{
    public DateTime PublishedAt { get; set; } = DateTime.UtcNow;
}