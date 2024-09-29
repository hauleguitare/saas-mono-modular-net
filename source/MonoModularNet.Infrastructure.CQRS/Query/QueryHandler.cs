using MediatR;

namespace MonoModularNet.Infrastructure.CQRS.Query;

public abstract class QueryHandler<TQuery, TResponse>: IRequestHandler<TQuery, TResponse> where TQuery : Query<TResponse>
{
    public abstract Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken);
}