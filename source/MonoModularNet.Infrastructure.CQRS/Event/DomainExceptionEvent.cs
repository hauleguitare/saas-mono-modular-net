using Core.Exception;
using MediatR;

namespace MonoModularNet.Infrastructure.CQRS.Event;

public class DomainExceptionEvent: DomainEvent, INotification
{
    public string[]? Errors { get; set; }
    public string[]? Messages { get; set; }
    
    public DomainException? Exception { get; set; }

    public static DomainExceptionEvent CreateExceptionDomainEvent(string[]? errors, string[]? messages, DomainException? exception)
    {
        return new DomainExceptionEvent()
        {
            Errors = errors,
            Messages = messages,
            Exception = exception
        };
    }
}