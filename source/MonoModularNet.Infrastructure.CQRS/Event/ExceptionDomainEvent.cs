using MediatR;

namespace MonoModularNet.Infrastructure.CQRS.Event;

public class ExceptionDomainEvent: DomainEvent, INotification
{
    public string[]? Errors { get; set; }
    public string[]? Messages { get; set; }

    public static ExceptionDomainEvent CreateExceptionDomainEvent(string[]? errors, string[]? messages)
    {
        return new ExceptionDomainEvent()
        {
            Errors = errors,
            Messages = messages
        };
    }
}