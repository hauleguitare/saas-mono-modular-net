namespace Core.Entity.Storage;

public class StorageEntityMetadata: BaseEntity<int>
{
    public int EntityId { get; set; }
    public bool IsTemplate { get; set; } = false;
    
    public virtual StorageEntity? Entity { get; set; }
}