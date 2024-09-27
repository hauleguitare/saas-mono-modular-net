using MediatR;

namespace Infrastructure.CQRS.Command;

public interface ICommand
{
    public DateTime? CommandedAt { get; set; } 
}

public abstract class Command : IRequest, ICommand
{
    public virtual DateTime? CommandedAt { get; set; } = DateTime.UtcNow;
}


public abstract class Command<T>: IRequest<T>, ICommand
{
    public virtual DateTime? CommandedAt { get; set; } = DateTime.UtcNow;
}