using MediatR;

namespace MonoModularNet.Infrastructure.CQRS.Command;

public interface ICqrsCommand
{
    public DateTime? CommandedAt { get; set; } 
}

public abstract class CqrsCommand : IRequest, ICqrsCommand
{
    public virtual DateTime? CommandedAt { get; set; } = DateTime.UtcNow;
}


public abstract class CqrsCommand<T>: IRequest<T>, ICqrsCommand
{
    public virtual DateTime? CommandedAt { get; set; } = DateTime.UtcNow;
}