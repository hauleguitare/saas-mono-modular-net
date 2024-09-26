using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SharedKernel.Common.Event;

namespace Core.Entity;


public abstract class DefaultStringPrimaryKeyEntity : BaseEntity<string>
{
    protected DefaultStringPrimaryKeyEntity() => Id = Guid.NewGuid().ToString("N");
}

public abstract class BaseEntityNoDefinedKey : AbstractBaseEntity
{
}

public abstract class BaseEntityCompositeKey : AbstractBaseEntity
{
    public abstract object GetCompositeKey();
}


public abstract class AbstractBaseEntity: IEntity
{
    [JsonIgnore]
    [NotMapped] 
    public List<IEvent> DomainEvents { get; } = new();

    protected virtual void PushEvent(IEvent @event)
    {
        DomainEvents.Add(@event);
    }

    protected virtual void RemoveEvent(IEvent @event)
    {
        DomainEvents.Remove(@event);
    }

    protected virtual void ClearEvent()
    {
        DomainEvents.Clear();
    }
}

public abstract class BaseEntity<TId>: AbstractBaseEntity
{
    public virtual TId Id { get; init; } = default!;
    
    public override bool Equals(object? obj)
    {
        if (obj is not BaseEntity<object> other)
        {
            return false;
        }

        return this.GetHashCode() == other.GetHashCode();

    }
    
    public static bool operator ==(BaseEntity<TId> a, BaseEntity<TId>? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }
    
    public static bool operator !=(BaseEntity<TId>? a, BaseEntity<TId>? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;
        
        return !a.Equals(b);
    }
    
    public override int GetHashCode()
    {
        int hash = 17;
        
        hash = hash * 23 + Id.GetHashCode();

        return hash;
    }
}
