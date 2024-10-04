using MediatR;

namespace MonoModularNet.Infrastructure.CQRS.Query;

public abstract class CqrsQueryHandler<TQuery, TResponse>: IRequestHandler<TQuery, TResponse> where TQuery : CqrsQuery<TResponse>
{
    public abstract Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken);
}