using MediatR;

namespace MonoModularNet.Infrastructure.CQRS.Mediator;

public interface IMediatorHandler: IDisposable
{
    Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request,
        CancellationToken cancellationToken = default);
    
    Task SendAsync(IRequest request,
        CancellationToken cancellationToken = default);

    Task PublishAsync(INotification @event, CancellationToken cancellationToken = default);

    IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request,
        CancellationToken cancellationToken = default) where TResponse :  class, new();

}