using Microsoft.Extensions.DependencyInjection;
using MonoModularNet.Infrastructure.Shared.Common.Attribute;

namespace MonoModularNet.Infrastructure.Shared.Common.Notification;

public class ExceptionDomain
{
    public Guid Id { get; set; }
    public string[]? Errors { get; set; }
    public string[]? Messages { get; set; }
}


public interface IExceptionDomainEventQueue : IDisposable
{
    void Enqueue(ExceptionDomain exceptionDomain);

    bool HasException();

    ExceptionDomain Dequeue();

    void Clear();
}

[Injectable(InterfaceType = typeof(IExceptionDomainEventQueue), Lifetime = ServiceLifetime.Scoped)]
public class ExceptionDomainEventQueue: IExceptionDomainEventQueue
{
    private readonly Queue<ExceptionDomain> _exceptionQueue = new Queue<ExceptionDomain>();
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public void Enqueue(ExceptionDomain exceptionDomain)
    {
        _exceptionQueue.Enqueue(exceptionDomain);
    }

    public bool HasException()
    {
        return _exceptionQueue.Count > 0;
    }

    public ExceptionDomain Dequeue()
    {
        return _exceptionQueue.Dequeue();
    }

    public void Clear()
    {
        _exceptionQueue.Clear();
    }
}