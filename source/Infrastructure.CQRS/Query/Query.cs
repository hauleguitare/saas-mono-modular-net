using MediatR;

namespace Infrastructure.CQRS.Query;

public interface IQuery
{
    public DateTime? QueriedAt { get; set; }
}

public abstract class Query<T>: IRequest<T>, IQuery
{
    public DateTime? QueriedAt { get; set; } = DateTime.UtcNow;
}