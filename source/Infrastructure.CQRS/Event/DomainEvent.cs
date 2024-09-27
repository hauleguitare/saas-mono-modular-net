using MediatR;
using SharedKernel.Common.Event;

namespace Infrastructure.CQRS.Event;

public abstract class DomainEvent: INotification, IEvent
{
    public virtual DateTime PublishedAt { get; set; } = DateTime.UtcNow;
}