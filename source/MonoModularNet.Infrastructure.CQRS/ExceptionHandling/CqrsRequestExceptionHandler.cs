using MediatR;
using MediatR.Pipeline;
using MonoModularNet.Infrastructure.CQRS.Response;

namespace MonoModularNet.Infrastructure.CQRS.ExceptionHandling;

public class CqrsRequestExceptionHandler<TRequest, TResponse, TException>: IRequestExceptionHandler<TRequest, TResponse, TException>
    where TResponse: CqrsResult, new() where TException: Exception where TRequest: IRequest
{
    public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state,
        CancellationToken cancellationToken)
    {

        var response = new TResponse()
        {
            IsSuccess = false,
            Errors = new[]
            {
                exception.Message
            }
        };
        
        state.SetHandled(response);

        return Task.CompletedTask;
    }
}