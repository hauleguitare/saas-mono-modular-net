using MediatR;

namespace MonoModularNet.Infrastructure.CQRS.Command;

public abstract class CqrsCommandHandler<TCommand, TResponse>: IRequestHandler<TCommand, TResponse> where TCommand : CqrsCommand<TResponse>
{
    public abstract Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken);
}

public abstract class CqrsCommandHandler<TCommand>: IRequestHandler<TCommand> where TCommand : CqrsCommand
{
    public abstract Task Handle(TCommand request, CancellationToken cancellationToken);
}