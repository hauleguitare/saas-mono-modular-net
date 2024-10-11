using Core.Exception;
using Microsoft.Extensions.DependencyInjection;
using MonoModularNet.Infrastructure.Shared.Common.Attribute;

namespace MonoModularNet.Infrastructure.Shared.Common.Notification;

public interface IDomainExceptionMessageEventQueue : IDisposable
{
    void Enqueue(DomainException domainException);

    bool HasException();

    DomainException Dequeue();

    void Clear();
}

[Injectable(InterfaceType = typeof(IDomainExceptionMessageEventQueue), Lifetime = ServiceLifetime.Scoped)]
public class DomainExceptionMessageEventQueue: IDomainExceptionMessageEventQueue
{
    private readonly Queue<DomainException> _exceptionQueue = new Queue<DomainException>();
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public void Enqueue(DomainException domainExceptionMessage)
    {
        _exceptionQueue.Enqueue(domainExceptionMessage);
    }

    public bool HasException()
    {
        return _exceptionQueue.Count > 0;
    }

    public DomainException Dequeue()
    {
        return _exceptionQueue.Dequeue();
    }

    public void Clear()
    {
        _exceptionQueue.Clear();
    }
}