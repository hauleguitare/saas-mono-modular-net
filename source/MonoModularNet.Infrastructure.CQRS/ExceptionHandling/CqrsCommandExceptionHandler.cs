using MediatR.Pipeline;
using MonoModularNet.Infrastructure.CQRS.Command;
using MonoModularNet.Infrastructure.CQRS.Event;
using MonoModularNet.Infrastructure.CQRS.Mediator;
using MonoModularNet.Infrastructure.CQRS.Response;

namespace MonoModularNet.Infrastructure.CQRS.ExceptionHandling;

public class CqrsCommandExceptionHandler<TRequest, TResponse, TException>: IRequestExceptionHandler<TRequest, TResponse, TException>
where TRequest : ICqrsCommand, new()
where TResponse : ICqrsResult, new()
where TException : Exception
{
    private readonly IMediatorHandler _mediatorHandler;

    public CqrsCommandExceptionHandler(IMediatorHandler mediatorHandler)
    {
        _mediatorHandler = mediatorHandler;
    }

    public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state,
        CancellationToken cancellationToken)
    {
        
        HandleCatchExceptionAsync(exception);
        
        state.SetHandled(new TResponse()
        {
            IsSuccess = false
        });
        
        return Task.CompletedTask;
    }


    private Task HandleCatchExceptionAsync(Exception exception)
    {
        switch (exception)
        {
            case NotImplementedException:
                _mediatorHandler.PublishAsync(
                    ExceptionDomainEvent.CreateExceptionDomainEvent(null, null));
                break;
        }

        return Task.CompletedTask;
    }
}