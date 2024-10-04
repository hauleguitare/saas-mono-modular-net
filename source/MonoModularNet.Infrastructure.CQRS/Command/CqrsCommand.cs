using MediatR;
using MonoModularNet.Infrastructure.CQRS.Response;

namespace MonoModularNet.Infrastructure.CQRS.Command;

public interface ICqrsCommand
{
    public DateTime? CommandedAt { get; set; } 
}

public abstract class CqrsCommand : IRequest<CqrsResult>, ICqrsCommand
{
    public virtual DateTime? CommandedAt { get; set; } = DateTime.UtcNow;
}


public abstract class CqrsCommand<T>: IRequest<CqrsResult<T>>, ICqrsCommand
{
    public virtual DateTime? CommandedAt { get; set; } = DateTime.UtcNow;
}