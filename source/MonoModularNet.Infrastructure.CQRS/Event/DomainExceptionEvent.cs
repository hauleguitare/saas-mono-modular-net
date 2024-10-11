using Core.Exception;
using MediatR;

namespace MonoModularNet.Infrastructure.CQRS.Event;

public class DomainExceptionEvent: DomainEvent, INotification
{
    public DomainExceptionEvent(DomainException exception)
    {
        Exception = exception;
    }

    public DomainException Exception { get; set; }
}