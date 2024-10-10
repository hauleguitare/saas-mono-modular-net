using Core.Exception;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Hosting;
using MonoModularNet.Infrastructure.CQRS.Command;
using MonoModularNet.Infrastructure.CQRS.Event;
using MonoModularNet.Infrastructure.CQRS.Mediator;
using MonoModularNet.Infrastructure.CQRS.Response;

namespace MonoModularNet.Infrastructure.CQRS.ExceptionHandling;

public class CqrsCommandExceptionHandler<TRequest, TResponse, TException>: IRequestExceptionHandler<TRequest, TResponse, TException>
where TRequest : ICqrsCommand, new()
where TResponse : ICqrsResult, new()
where TException : DomainException
{
    private readonly IMediatorHandler _mediatorHandler;
    private readonly IWebHostEnvironment _environment;

    public CqrsCommandExceptionHandler(IMediatorHandler mediatorHandler, IWebHostEnvironment environment)
    {
        _mediatorHandler = mediatorHandler;
        _environment = environment;
    }

    public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state,
        CancellationToken cancellationToken)
    {
        _mediatorHandler.PublishAsync(
            DomainExceptionEvent.CreateExceptionDomainEvent(null, null, exception), cancellationToken);
        
        state.SetHandled(new TResponse()
        {
            IsSuccess = false,
            Errors = exception.Errors,
            Messages = exception.Messages
        });
        
        return Task.CompletedTask;
    }

    
}