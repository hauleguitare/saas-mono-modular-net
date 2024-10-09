using MediatR;
using MonoModularNet.Infrastructure.Shared.Common.Notification;

namespace MonoModularNet.Infrastructure.CQRS.Event;

public class ExceptionDomainEventHandler: INotificationHandler<ExceptionDomainEvent>
{
    private readonly IExceptionDomainEventQueue _queue;

    public ExceptionDomainEventHandler(IExceptionDomainEventQueue queue)
    {
        _queue = queue;
    }
    

    public Task Handle(ExceptionDomainEvent notification, CancellationToken cancellationToken)
    {
        _queue.Enqueue(new ExceptionDomain()
        {
            Id = Guid.NewGuid(),
            Errors = notification.Errors,
            Messages = notification.Messages
        });
        
        return Task.CompletedTask;
    }
}