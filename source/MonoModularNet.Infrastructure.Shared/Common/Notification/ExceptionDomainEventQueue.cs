using Microsoft.Extensions.DependencyInjection;
using MonoModularNet.Infrastructure.Shared.Common.Attribute;

namespace MonoModularNet.Infrastructure.Shared.Common.Notification;

public class DomainExceptionMessage
{
    public Guid Id { get; set; }
    public string[]? Errors { get; set; }
    public string[]? Messages { get; set; }
}


public interface IDomainExceptionMessageEventQueue : IDisposable
{
    void Enqueue(DomainExceptionMessage domainExceptionMessage);

    bool HasException();

    DomainExceptionMessage Dequeue();

    void Clear();
}

[Injectable(InterfaceType = typeof(IDomainExceptionMessageEventQueue), Lifetime = ServiceLifetime.Scoped)]
public class DomainExceptionMessageEventQueue: IDomainExceptionMessageEventQueue
{
    private readonly Queue<DomainExceptionMessage> _exceptionQueue = new Queue<DomainExceptionMessage>();
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public void Enqueue(DomainExceptionMessage domainExceptionMessage)
    {
        _exceptionQueue.Enqueue(domainExceptionMessage);
    }

    public bool HasException()
    {
        return _exceptionQueue.Count > 0;
    }

    public DomainExceptionMessage Dequeue()
    {
        return _exceptionQueue.Dequeue();
    }

    public void Clear()
    {
        _exceptionQueue.Clear();
    }
}