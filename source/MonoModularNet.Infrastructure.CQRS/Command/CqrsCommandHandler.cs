using MediatR;
using MonoModularNet.Infrastructure.CQRS.Response;

namespace MonoModularNet.Infrastructure.CQRS.Command;

public abstract class CqrsCommandHandler<TCommand, TResponse>: IRequestHandler<TCommand, CqrsResult<TResponse>> where TCommand : CqrsCommand<TResponse>
{
    public abstract Task<CqrsResult<TResponse>> Handle(TCommand request, CancellationToken cancellationToken);
}

public abstract class CqrsCommandHandler<TCommand>: IRequestHandler<TCommand, CqrsResult> where TCommand : CqrsCommand
{
    public abstract Task<CqrsResult> Handle(TCommand request, CancellationToken cancellationToken);
}