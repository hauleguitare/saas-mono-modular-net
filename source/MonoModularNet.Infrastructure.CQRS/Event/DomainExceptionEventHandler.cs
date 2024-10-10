using MediatR;
using MonoModularNet.Infrastructure.Shared.Common.Notification;

namespace MonoModularNet.Infrastructure.CQRS.Event;

public class DomainExceptionEventHandler: INotificationHandler<DomainExceptionEvent>
{
    private readonly IDomainExceptionMessageEventQueue _queue;

    public DomainExceptionEventHandler(IDomainExceptionMessageEventQueue queue)
    {
        _queue = queue;
    }
    

    public Task Handle(DomainExceptionEvent notification, CancellationToken cancellationToken)
    {
        _queue.Enqueue(new DomainExceptionMessage()
        {
            Id = Guid.NewGuid(),
            Errors = notification.Errors,
            Messages = notification.Messages
        });
        
        return Task.CompletedTask;
    }
}