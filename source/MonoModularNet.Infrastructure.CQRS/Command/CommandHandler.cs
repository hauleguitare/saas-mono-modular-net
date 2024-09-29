using MediatR;

namespace MonoModularNet.Infrastructure.CQRS.Command;

public abstract class CommandHandler<TCommand, TResponse>: IRequestHandler<TCommand, TResponse> where TCommand : Command<TResponse>
{
    public abstract Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken);
}

public abstract class CommandHandler<TCommand>: IRequestHandler<TCommand> where TCommand : Command
{
    public abstract Task Handle(TCommand request, CancellationToken cancellationToken);
}