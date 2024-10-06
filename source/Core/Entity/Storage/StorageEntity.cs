namespace Core.Entity.Storage;

public class StorageEntity: BaseEntity<int>
{
    public StorageEntity()
    {
        Metadata = new StorageEntityMetadata();
    }
    
    public string Name { get; set; } = null!;
    
    public virtual StorageEntityMetadata? Metadata { get; set; }
}