using Core.Exception;
using MediatR;
using MonoModularNet.Infrastructure.CQRS.Event;

namespace MonoModularNet.Infrastructure.CQRS.Mediator;

public class MediatorHandler: IMediatorHandler
{
    private readonly IMediator _mediator;

    public MediatorHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        return _mediator.Send(request, cancellationToken);
    }

    public Task SendAsync(IRequest request, CancellationToken cancellationToken = default)
    {
        return _mediator.Send(request, cancellationToken);
    }

    public Task PublishAsync(INotification @event, CancellationToken cancellationToken = default)
    {
        return _mediator.Publish(@event, cancellationToken);
    }

    public Task RaiseExceptionAsync(DomainException exception, CancellationToken cancellationToken = default)
    {
        return _mediator.Publish(new DomainExceptionEvent(exception));
    }

    public IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request, CancellationToken cancellationToken = default) where TResponse :  class, new()
    {
        return _mediator.CreateStream(request, cancellationToken);
    }


    private bool _disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // do something when disposing...
            }
        }
        _disposed = true;
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}