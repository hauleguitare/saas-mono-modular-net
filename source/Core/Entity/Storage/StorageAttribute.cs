namespace Core.Entity.Storage;

public class StorageAttribute: BaseEntity<int>
{
    public StorageAttribute()
    {
        Metadata = new StorageAttributeMetadata();
    }
    
    public string Name { get; set; } = null!;
    
    public virtual StorageAttributeMetadata? Metadata { get; set; }
}