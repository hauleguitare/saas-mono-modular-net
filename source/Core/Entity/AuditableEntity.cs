namespace Core.Entity;

public class AuditableEntity: DefaultAuditableEntity
{
    
}

public class DefaultAuditableEntity : AuditableEntity<string>
{
    
}


public abstract class AuditableEntity<TId>: BaseEntity<TId>, IAuditableEntity
{
    public virtual DateTimeOffset? CreatedAt { get; set; }
    public virtual DateTimeOffset? ModifiedAt { get; set; }
    public virtual string? CreatedBy { get; set; }
    public virtual string? ModifiedBy { get; set; }
}

public interface IAuditableEntity
{
    /// <summary>
    /// Timestamp for created time entities.
    /// </summary>
    public DateTimeOffset? CreatedAt { get; set; }
    
    /// <summary>
    /// Timestamp for modified time entities.
    /// </summary>
    public DateTimeOffset? ModifiedAt { get; set; }
    
    /// <summary>
    /// Identity ID for created time entities.
    /// </summary>
    public string? CreatedBy { get; set; }
    
    /// <summary>
    /// Identity ID for modified time entities.
    /// </summary>
    public string? ModifiedBy { get; set; }
}
